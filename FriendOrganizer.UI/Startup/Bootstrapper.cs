using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModels;
using Microsoft.Extensions.Configuration;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        { 
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            builder.Register(context =>
            {
                var factory = new FriendOrganizerDbContextFactory();
                return factory.CreateDbContext(Array.Empty<string>());
            })
            .As<FriendOrganizerDbContext>()
            .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
