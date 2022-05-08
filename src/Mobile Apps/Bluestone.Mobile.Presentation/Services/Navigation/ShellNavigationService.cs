using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.Services.Preference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.Navigation
{
    public class ShellNavigationService : IShellNavigationService
    {
        private readonly IPreferenceService _preferenceService;

        public ShellNavigationService(IPreferenceService preferenceService)
        {
            _preferenceService = preferenceService;
        }

        public Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(_preferenceService.AuthAccessToken))
            {
                return GoToAsync("//", AppRoutingConstants.LoginPageRoute);
            }
            else
            {
                return GoToAsync("//", AppRoutingConstants.LoginWithFingerPrintPageRoute);
            }
        }

        public Task PopAsync()
        {
            return Shell.Current.Navigation.PopAsync();
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public Task InsertAsRoot(string route, IDictionary<string, string> routeParameters = null)
        {
            return GoToAsync("//", route, routeParameters);
        }

        public Task PushAsync(string route, IDictionary<string, string> routeParameters = null)
        {
            return GoToAsync("", route, routeParameters);
        }

        private Task GoToAsync(string routePrefix, string route, IDictionary<string, string> routeParameters = null)
        {
            var uri = new StringBuilder(routePrefix + route);

            if (routeParameters != null)
            {
                uri.Append('?');

                foreach (var routeParameter in routeParameters)
                {
                    uri.Append($"{routeParameter.Key}={Uri.EscapeDataString(routeParameter.Value)}&");
                }
                uri.Remove(uri.Length - 1, 1);
            }
            return Shell.Current.GoToAsync(uri.ToString());
        }


        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}