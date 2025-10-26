using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public interface ILookupDataService
    {
        Task<IEnumerable<Lookupitem>> GetFriendLookupAsync();
    }
}