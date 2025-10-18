using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            modelBuilder.Entity<Friend>().HasData(
                new Friend
                {
                    Id = 1,
                    FirstName = "Thomas",
                    LastName = "Miner",
                    Email = "thomas@example.com"
                },
                new Friend
                {
                    Id = 2,
                    FirstName = "Hans",
                    LastName = "Kolbe",
                    Email = "hans@example.com"
                },
                new Friend
                {
                    Id = 3,
                    FirstName = "Misha",
                    LastName = "Walter",
                    Email = "walter@gmail.com"
                },
                new Friend
                {
                    Id = 4,
                    FirstName = "Heiner",
                    LastName = "Mueller",
                    Email = "mueller@gmail.com"
                }
            );

            //modelBuilder.Entity<Friend>()
            //    .Property(f => f.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            // modelBuilder.ApplyConfiguration(new FriendConfiguration());
        }
    }

    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new Friend { Id = 1, FirstName = "Thomas", LastName = "Miner", Email = "thomas@example.com" },
                new Friend { Id = 2, FirstName = "Hans", LastName = "Kolbe", Email = "hans@example.com" } 
            );
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
