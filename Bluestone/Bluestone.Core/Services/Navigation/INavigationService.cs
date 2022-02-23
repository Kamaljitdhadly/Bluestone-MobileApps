using Bluestone.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Core.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync (string route, IDictionary<string, string> routeParameters = null);
    }
}