using Bluestone.Core.DataServices;
using Bluestone.Core.Models.Dashboard;
using Bluestone.Core.Services.Dashboard;
using Bluestone.Core.Services.Dependency;
using Bluestone.Core.Services.Dialog;
using Bluestone.Core.Services.Identity;
using Bluestone.Core.Services.Messages;
using Bluestone.Core.Services.Navigation;
using Bluestone.Core.Services.OpenUrl;
using Bluestone.Core.Services.RequestProvider;
using Bluestone.Core.Services.Settings;
using Bluestone.Core.ViewModels.Dashboard;
using Bluestone.Core.ViewModels.Identity;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        static ViewModelLocator()
        {
            // Services - by default, TinyIoC will register interface registrations as singletons.
            var settingsService = new SettingsService();
            var requestProvider = new RequestProvider();
            Xamarin.Forms.DependencyService.RegisterSingleton<IDataStore>(new MockDataStore());
            Xamarin.Forms.DependencyService.RegisterSingleton<IDependencyService>(new Services.Dependency.DependencyService());
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

        public static T Resolve<T>() where T : class
        {
            return Xamarin.Forms.DependencyService.Get<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }

            var viewModel = Activator.CreateInstance(viewModelType);

            view.BindingContext = viewModel;
        }
    }
}