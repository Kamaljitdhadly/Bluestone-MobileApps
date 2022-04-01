using Bluestone.Domain.Models.Account;
using Bluestone.Domain.Services.Account;
using Bluestone.Presentation.GlobalSettings;
using Bluestone.Presentation.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Account
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly IAccountService _accountService;

        private ObservableCollection<AccountOptions> _accountOptions;

        public AccountViewModel()
        {
            _accountService = DependencyService.Get<IAccountService>();
        }

        public ICommand EditProfileCommand => new Command(async () => await EditProfileClicked());
        public ICommand ChangePasswordCommand => new Command(async () => await ChangePasswordClicked());
        public ICommand SettingsCommand => new Command(async () => await SettingsClicked());
        public ICommand HelpCommand => new Command(async () => await HelpClicked());
        public ICommand TermsCommand => new Command(async () => await TermsServiceClicked());
        public ICommand LogoutCommand => new Command(async () => await LogoutClicked());

        public ObservableCollection<AccountOptions> AccountOptions
        {
            get => _accountOptions;
            set
            {
                _accountOptions = value;
                RaisePropertyChanged(() => AccountOptions);
            }
        }

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            AccountOptions = await _accountService.GetAccountOptionsAsync();
            IsBusy = false;
        }

        private async Task EditProfileClicked()
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.SettingsPageRoute);
        }


        private async Task ChangePasswordClicked()
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.SettingsPageRoute);
        }

        private async Task SettingsClicked()
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.SettingsPageRoute);
        }

        private async Task TermsServiceClicked()
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.SettingsPageRoute);
        }

        private async Task HelpClicked()
        {
            await ShellNavigationService.PushAsync(AppRoutingConstants.SettingsPageRoute);
        }

        private async Task LogoutClicked()
        {
            await ShellNavigationService.InsertAsRoot(AppRoutingConstants.LoginPageRoute);
        }


    }
}
