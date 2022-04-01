using Bluestone.Domain.Services.Identity;
using Bluestone.Presentation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Identity
{
    public class ResetPasswordViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;

        public ResetPasswordViewModel()
        {
            _identityService = DependencyService.Get<IIdentityService>();
        }

        public ICommand ResetPasswordCommand => new Command(async () => await ResetPasswordAsync());

        private Task ResetPasswordAsync()
        {
            return _identityService.ResetPasswordAsync("User");
        }
    }
}
