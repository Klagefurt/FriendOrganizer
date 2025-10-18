using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            // TODO: Load data from real database
            yield return new Friend { FirstName = "Thomas", LastName = "Miner" };
            yield return new Friend { FirstName = "Heiner", LastName = "Muellerr" };
            yield return new Friend { FirstName = "Lukas", LastName = "Gobbs" };
            yield return new Friend { FirstName = "John", LastName = "Smith" };
        }
    }
}
