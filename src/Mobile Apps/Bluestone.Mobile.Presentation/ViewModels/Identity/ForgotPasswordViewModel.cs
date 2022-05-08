using Bluestone.Mobile.Domain.Services.Identity;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Identity
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;

        public ForgotPasswordViewModel()
        {
            _identityService = DependencyService.Get<IIdentityService>();
        }

        public ICommand SignUpCommand => new Command(async () => await SignUpClickedAsync());
        public ICommand ForgotPasswordCommand => new Command(async () => await ForgotPasswordAsync());
        public ICommand BackButtonCommand => new Command(async () => await BackButtonClickedAsync());


        private Task SignUpClickedAsync()
        {
            return _identityService.ForgotPasswordAsync("User");
        }

        private Task ForgotPasswordAsync()
        {
            return _identityService.ForgotPasswordAsync("User");
        }

        private Task BackButtonClickedAsync()
        {
            return _identityService.ForgotPasswordAsync("User");
        }

    }
}
