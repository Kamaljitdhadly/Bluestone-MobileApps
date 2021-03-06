using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.Navigation
{
    public interface IShellNavigationService
    {
        Task InitializeAsync();
        Task PushAsync(string route, IDictionary<string, string> routeParameters = null);
        Task PopAsync();
        Task InsertAsRoot(string route, IDictionary<string, string> routeParameters = null);
        Task GoBackAsync();
    }
}