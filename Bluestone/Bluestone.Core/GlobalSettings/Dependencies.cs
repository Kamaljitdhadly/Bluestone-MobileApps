using Bluestone.Core.DataServices;
using Bluestone.Core.Services.Dashboard;
using Bluestone.Core.Services.Dialog;
using Bluestone.Core.Services.Identity;
using Bluestone.Core.Services.Messages;
using Bluestone.Core.Services.Navigation;
using Bluestone.Core.Services.OpenUrl;
using Bluestone.Core.Services.RequestProvider;
using Bluestone.Core.Services.Settings;
using Bluestone.Core.ViewModels.Dashboard;
using Bluestone.Core.ViewModels.Identity;

namespace Bluestone.Core.GlobalSettings
{
    public static class Dependencies
    {
        public static void Register()
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var settingsService = new SettingsService();
            var requestProvider = new RequestProvider();
            Xamarin.Forms.DependencyService.RegisterSingleton<IDataStore>(new MockDataStore());
            Xamarin.Forms.DependencyService.RegisterSingleton<ISettingsService>(settingsService);
            Xamarin.Forms.DependencyService.RegisterSingleton<INavigationService>(new NavigationService(settingsService));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDialogService>(new DialogService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IOpenUrlService>(new OpenUrlService());
            Xamarin.Forms.DependencyService.RegisterSingleton<IRequestProvider>(requestProvider);
            Xamarin.Forms.DependencyService.RegisterSingleton<IIdentityService>(new IdentityService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<IMessageService>(new MessageService(requestProvider));
            Xamarin.Forms.DependencyService.RegisterSingleton<IDashboardService>(new DashboardService(requestProvider));

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            Xamarin.Forms.DependencyService.Register<LoginViewModel>();
            Xamarin.Forms.DependencyService.Register<AboutViewModel>();
            Xamarin.Forms.DependencyService.Register<ItemDetailViewModel>();
            Xamarin.Forms.DependencyService.Register<ItemsViewModel>();
            Xamarin.Forms.DependencyService.Register<NewItemViewModel>();
        }
    }
}
