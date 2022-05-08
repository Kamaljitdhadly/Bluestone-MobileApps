using Bluestone.Droid.Services.ApplicationState;
using Bluestone.Mobile.Presentation.Services.ApplicationStateService;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(ApplicationStateService))]
namespace Bluestone.Droid.Services.ApplicationState
{
    public class ApplicationStateService : IApplicationStateService
    {
        public bool IsApplicationActive => throw new NotImplementedException();
    }
}
