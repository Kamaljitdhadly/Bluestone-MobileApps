using Bluestone.Mobile.CrossCuttingConcerns.Helpers;
using Bluestone.Mobile.Domain.Services.Identity;
using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.Services.Toast;
using Bluestone.Mobile.Presentation.Validations;
using Bluestone.Mobile.Presentation.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.ViewModels.Identity
{
    public class LoginViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;

        private bool _isValid;
        private bool _isLogin;

        private readonly IIdentityService _identityService;

        public LoginViewModel()
        {
            _identityService = DependencyService.Get<IIdentityService>();

            _userName = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
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

        public bool IsLogin
        {
            get => _isLogin;
            set
            {
                _isLogin = value;
                RaisePropertyChanged(() => IsLogin);
            }
        }


        public ICommand SignInCommand => new Command(async () => await SignInAsync());

        public ICommand SignUpCommand => new Command(async () => await SignUpAsync());
        public ICommand ForgotPasswordCommand => new Command(async () => await ForgotPasswordAsync());

        public ICommand ValidateUserNameCommand => new Command(() => ValidateUserName());

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
                var toastService = DependencyService.Get<IToastMessageService>();
                toastService.ShortAlert("All fields are mandatory!");
                return;
            }


            bool isAuthenticated = await _identityService.SignInAsync(_userName.Value, _password.Value);

            if (!isAuthenticated)
            {
                IsBusy = false;
                return;
            }

            PreferenceService.AuthAccessToken = "token";
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.DoListInboxPageRoute);
            IsBusy = false;

        }

        private async Task SignUpAsync()
        {
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.SignUpPageRoute);
        }

        private async Task ForgotPasswordAsync()
        {
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.ForgotPasswordPageRoute);
        }

        private bool Validate()
        {
            bool isValidUser = ValidateUserName();
            bool isValidPassword = ValidatePassword();

            return isValidUser && isValidPassword;
        }

        private bool ValidateUserName()
        {
            return _userName.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = ConstantsHelper.Errors.RequiredUsernameError });
            _password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = ConstantsHelper.Errors.RequiredPasswordError });
        }
    }
}
