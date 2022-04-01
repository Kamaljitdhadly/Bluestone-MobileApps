using Bluestone.Domain.Models.Account;
using Bluestone.Domain.Services.Account;
using Bluestone.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Application.Account
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
