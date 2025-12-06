using FriendOrganizer.UI.Events;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set 
            { 
                _displayMember = value; 
                OnPropertyChanged();
            }
        }

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            Id = id;
            DisplayMember = displayMember;
            OpenFriendDetailViewCommand = new DelegateCommand(OnOpenFriendDetailView);
        }

        private void OnOpenFriendDetailView()
        {
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Publish(Id);
        }

        public ICommand OpenFriendDetailViewCommand { get; }
    }
}
