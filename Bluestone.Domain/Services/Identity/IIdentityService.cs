using Bluestone.Domain.Models.Identity;
using Bluestone.Domain.Models.Token;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Identity
{
    public interface IIdentityService
    {
        string CreateLogoutRequest(string token);

        Task<UserToken> GetTokenAsync(string code);

        Task<bool> SignInAsync(string email, string password);

        Task<bool> RegisterUserAsync(string user);

        Task<bool> ResetPasswordAsync(string user);

        Task<bool> ForgotPasswordAsync(string user);

    }
}