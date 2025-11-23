using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Events;
using FriendOrganizer.UI.Wrapper;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModels
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _friendDataService;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;

        public FriendDetailViewModel(IFriendDataService friendDataService, IEventAggregator eventAggregator)
        {
            _friendDataService = friendDataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await _friendDataService.GetByIdAsync(friendId);
            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Friend.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
        }

        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _friendDataService.SaveAsync(Friend.Model);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>()
                .Publish(new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMemeber = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            // TODO: change if friend has changes
            return Friend != null && !Friend.HasErrors;
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }
    }
}
