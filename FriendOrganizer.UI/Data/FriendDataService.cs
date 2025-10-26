using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        //private readonly FriendOrganizerDbContext _context;

        //public FriendDataService(FriendOrganizerDbContext dbContext)
        //{
        //    _context = dbContext;
        //}


        public async Task<Friend> GetByIdAsync(int friendId)
        {
            await using var ctx = _contextCreator();

            return await ctx.Friends.AsNoTracking().SingleAsync(f => f.Id == friendId); 

            // TODO: Load data from real database
            //return _context.Friends.AsNoTracking().ToList();

            //yield return new Friend { FirstName = "Thomas", LastName = "Miner" };
            //yield return new Friend { FirstName = "Heiner", LastName = "Muellerr" };
            //yield return new Friend { FirstName = "Lukas", LastName = "Gobbs" };
            //yield return new Friend { FirstName = "John", LastName = "Smith" };
        }
    }
}
