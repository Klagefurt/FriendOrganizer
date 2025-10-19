using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // UI
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            // Data Service
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            // 1. Factory registration --- REUSING FACTORY, AVOIDING DUPLICATION
            //builder.Register(_ =>
            //{
            //    var factory = new FriendOrganizerDbContextFactory();
            //    return factory.CreateDbContext([]);
            //})
            //.As<FriendOrganizerDbContext>()
            //.InstancePerLifetimeScope();

            //return builder.Build();

            // 2. Extracting a shared helper
            builder.Register(_ => new FriendOrganizerDbContext(DbContextFactoryHelper.BuildOptions()))
                .As<FriendOrganizerDbContext>()
                .InstancePerLifetimeScope();

            return builder.Build();

            // 3. DUPLICATING DbContext creation logic

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = config.GetConnectionString("FriendOrganizerDb");

            //builder.Register(_ =>
            //{

            //    var optionsBuilder = new DbContextOptionsBuilder<FriendOrganizerDbContext>();
            //    optionsBuilder.UseSqlServer(connectionString);
            //    return new FriendOrganizerDbContext(optionsBuilder.Options);
            //}).AsSelf();

            //return builder.Build();
        }
    }
}
