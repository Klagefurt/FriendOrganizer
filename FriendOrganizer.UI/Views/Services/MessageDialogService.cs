using System.Windows;

namespace FriendOrganizer.UI.Views.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            var result = MessageBox.Show(text, title, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
                return MessageDialogResult.OK;
            else
                return MessageDialogResult.Cancel;
        }
    }

    public enum MessageDialogResult
    {
        OK,
        Cancel
    }
}
