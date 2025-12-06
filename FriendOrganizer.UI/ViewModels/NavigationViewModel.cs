using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Events;
using System.Collections.ObjectModel;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookupDataService _friendLookupDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Friends { get; }

        //private NavigationItemViewModel _selectedFriend;

        //public NavigationItemViewModel SelectedFriend
        //{
        //    get { return _selectedFriend; }
        //    set 
        //    { 
        //        _selectedFriend = value; 
        //        OnPropertyChanged();
        //        if (_selectedFriend != null)
        //        {
        //            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
        //                .Publish(_selectedFriend.Id);
        //        }
        //    }
        //}

        public NavigationViewModel(ILookupDataService friendLookupDataService, IEventAggregator eventAggregator)
        {
            _friendLookupDataService = friendLookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs args)
        {
            var lookupitem = Friends.SingleOrDefault(l => l.Id == args.Id);
            if (lookupitem == null)
            {
                Friends.Add(new NavigationItemViewModel(args.Id, args.DisplayMemeber, _eventAggregator));
            }
            else
            {
                lookupitem.DisplayMember = args.DisplayMemeber;
            }
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendLookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMemeber, _eventAggregator));
            }
        }
    }
}
