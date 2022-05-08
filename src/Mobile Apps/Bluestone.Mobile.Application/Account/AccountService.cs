using Bluestone.Mobile.Domain.Models.Account;
using Bluestone.Mobile.Domain.Services.Account;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Application.Account
{
    public class AccountService : IAccountService
    {
        private readonly IRequestProvider _requestProvider;

        private readonly ObservableCollection<AccountOptions> _mockAccount = new ObservableCollection<AccountOptions>
        {
            new AccountOptions
            {
                AccountOptionsId = 1,
                AccountOptionsName = "Profile",
                AccountOptionsDescription = "Profile",
                AccountOptionsIcon = "Profile",
            },
            new AccountOptions
            {
                AccountOptionsId = 2,
                AccountOptionsName = "Settings",
                AccountOptionsDescription = "Settings",
                AccountOptionsIcon = "Settings",
            }
        };


        public AccountService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }


        public async Task<ObservableCollection<AccountOptions>> GetAccountOptionsAsync()
        {
            return await Task.FromResult(_mockAccount);
        }
    }
}
