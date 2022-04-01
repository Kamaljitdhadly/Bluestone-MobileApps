using Bluestone.Domain.Services.Identity;
using Bluestone.Presentation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Identity
{
    public class SignUpViewModel : ViewModelBase
    {
        private readonly IIdentityService _identityService;

        public SignUpViewModel()
        {
            _identityService = DependencyService.Get<IIdentityService>();
        }

        public ICommand RegisterUserCommand => new Command(async () => await RegisterUserAsync());


        private Task RegisterUserAsync()
        {
            return _identityService.RegisterUserAsync("User");
        }

    }
}
