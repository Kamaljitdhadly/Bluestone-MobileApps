using Bluestone.Core.Models.Token;
using System.Threading.Tasks;

namespace Bluestone.Core.Services.Identity
{
    public interface IIdentityService
    {
        string CreateLogoutRequest(string token);
        Task<UserToken> GetTokenAsync(string code);
    }
}