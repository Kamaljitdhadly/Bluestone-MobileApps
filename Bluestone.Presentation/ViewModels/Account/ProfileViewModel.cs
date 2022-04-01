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
    public class ProfileViewModel : ViewModelBase
    {
        private readonly IAccountService _accountService;

        private ObservableCollection<AccountOptions> _accountOptions;

        public ProfileViewModel()
        {
            _accountService = DependencyService.Get<IAccountService>();
        }

        public ObservableCollection<AccountOptions> AccountOptions
        {
            get => _accountOptions;
            set
            {
                _accountOptions = value;
                RaisePropertyChanged(() => AccountOptions);
            }
        }

        public ICommand GetAccountDetailsCommand => new Command<AccountOptions>(async (item) => await GetAccountDetailsAsync(item));

        public override async Task InitializeAsync(IDictionary<string, string> query)
        {
            IsBusy = true;
            AccountOptions = await _accountService.GetAccountOptionsAsync();
            IsBusy = false;
        }

        private async Task GetAccountDetailsAsync(AccountOptions accountOptions)
        {

            if (accountOptions.AccountOptionsId == 1)
            {
                await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute);
            }
            else if (accountOptions.AccountOptionsId == 2)
            {
                await ShellNavigationService.PushAsync(AppRoutingConstants.MessageDetailsPageRoute);
            }

        }
    }
}
