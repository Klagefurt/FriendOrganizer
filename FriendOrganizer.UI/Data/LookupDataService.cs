using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Data
{
    public class LookupDataService : ILookupDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public LookupDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<Lookupitem>> GetFriendLookupAsync()
        {
            using var context = _contextCreator();

            return await context.Friends.AsNoTracking()
                .Select(f =>
                new Lookupitem
                {
                    Id = f.Id,
                    DisplayMemeber = f.FirstName + " " + f.LastName
                })
                .ToListAsync();
        }
    }
}
