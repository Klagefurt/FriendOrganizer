using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext(DbContextOptions<FriendOrganizerDbContext> options) : base(options)
        {
            
        }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class FriendOrganizerDbContextFactory : IDesignTimeDbContextFactory<FriendOrganizerDbContext>
    {
        public FriendOrganizerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("FriendOrganizerDB");

            var optionsBuilder = new DbContextOptionsBuilder<FriendOrganizerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FriendOrganizerDbContext(optionsBuilder.Options);
        }
    }
}
