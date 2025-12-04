using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.ViewModels;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Prism EventAggregator for communication between vms
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            // UI
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            
            // Data Service
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendRepository>().As<IFriendRepository>();

            // 1. Factory registration --- REUSING FACTORY, AVOIDING DUPLICATION
            //builder.Register(_ =>
            //{
            //    var factory = new FriendOrganizerDbContextFactory();
            //    return factory.CreateDbContext([]);
            //})
            //.As<FriendOrganizerDbContext>()
            //.InstancePerDependency();

            //return builder.Build();

            // 2. Extracting a shared helper
            builder.Register(_ => new FriendOrganizerDbContext(DbContextFactoryHelper.BuildOptions()))
                .As<FriendOrganizerDbContext>()
                .InstancePerDependency();

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
