using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Lookups
{
    public interface ILookupDataService
    {
        Task<IEnumerable<Lookupitem>> GetFriendLookupAsync();
    }
}