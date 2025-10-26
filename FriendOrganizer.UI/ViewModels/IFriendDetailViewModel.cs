
namespace FriendOrganizer.UI.ViewModels
{
    public interface IFriendDetailViewModel
    {
        Task LoadAsync(int friendId);
    }
}