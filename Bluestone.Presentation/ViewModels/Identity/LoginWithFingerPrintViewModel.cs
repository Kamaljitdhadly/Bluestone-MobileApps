using Bluestone.Domain.Services.Identity;
using Bluestone.Presentation.GlobalSettings;
using Bluestone.Presentation.Services.Settings;
using Bluestone.Presentation.Validations;
using Bluestone.Presentation.ViewModels.Base;
using Plugin.Fingerprint.Abstractions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Identity
{
    public class LoginWithFingerPrintViewModel : ViewModelBase
    {
        private ValidatableObject<string> _password;

        private bool _isValid;

        private readonly IIdentityService _identityService;
        private readonly ISettingsService _settingsService;

        public LoginWithFingerPrintViewModel()
        {
            _identityService = DependencyService.Get<IIdentityService>();
            _settingsService = DependencyService.Get<ISettingsService>();

            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public ICommand SignInCommand => new Command(async () => await SignInAsync());
        public ICommand SwitchAccountCommand => new Command(async () => await SwitchAccountAsync());
        public ICommand ForgotPasswordCommand => new Command(async () => await ForgotPasswordAsync());
        public ICommand BiometricCommand => new Command(async () => await BiometricAuthenticationAsync());
        public ICommand ValidatePasswordCommand => new Command(() => ValidatePassword());

        private async Task SignInAsync()
        {

            IsBusy = true;
            IsValid = true;
            bool isValid = Validate();

            if (!isValid)
            {
                IsBusy = false;
                IsValid = false;
                return;
            }


            bool isAuthenticated = await _identityService.SignInAsync("admin", _password.Value);

            if (!isAuthenticated)
            {
                IsBusy = false;
                return;
            }

            PreferenceService.AuthAccessToken = "token";
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.DoListInboxPageRoute);
            IsBusy = false;

        }

        private async Task BiometricAuthenticationAsync()
        {
            FingerprintAuthenticationResult result = await _settingsService.FingerprintAuthenticationAsync("Login to Bluestone", "Touch your finger on senser to login");

            if (!result.Authenticated)
            {
                return;
            }

            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.DoListInboxPageRoute);
        }

        private async Task SwitchAccountAsync()
        {
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.LoginPageRoute);
        }


        private async Task ForgotPasswordAsync()
        {
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.ForgotPasswordPageRoute);
        }


        private bool Validate()
        {
            bool isValidPassword = ValidatePassword();
            return isValidPassword;
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidations()
        {
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }

    }
}
