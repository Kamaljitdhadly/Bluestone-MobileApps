using Bluestone.Mobile.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.Services.Account
{
    public interface IAccountService
    {
        Task<ObservableCollection<AccountOptions>> GetAccountOptionsAsync();
    }
}
