using Bluestone.Mobile.Presentation.Services.ApplicationStateService;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Bluestone.iOS.Services.ApplicatonState.ApplicationStateService))]
namespace Bluestone.iOS.Services.ApplicatonState
{
    public class ApplicationStateService : IApplicationStateService
    {
        public bool IsApplicationActive => UIApplication.SharedApplication.ApplicationState != UIApplicationState.Background;
    }
}
