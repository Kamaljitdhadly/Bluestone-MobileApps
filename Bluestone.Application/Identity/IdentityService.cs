using Bluestone.Domain.ConfigurationOptions;
using Bluestone.Domain.Models.Identity;
using Bluestone.Domain.Models.Token;
using Bluestone.Domain.Services.Identity;
using Bluestone.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

namespace Bluestone.Application.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly string _codeVerifier = "";

        public IdentityService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public string CreateLogoutRequest(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return string.Empty;
            }

            return string.Format("{0}?id_token_hint={1}&post_logout_redirect_uri={2}",
                WebServiceEndpoints.LogoutEndpoint,
                token,
                WebServiceEndpoints.LogoutCallback);
        }

        public async Task<UserToken> GetTokenAsync(string code)
        {
            string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}", code, WebUtility.UrlEncode("ddd"), _codeVerifier);
            var token = await _requestProvider.PostAsync<UserToken>(WebServiceEndpoints.LoginEndpoint, data, "dddd", "ddd");
            return token;
        }


        public async Task<bool> SignInAsync(string email, string password)
        {
            if (email == "admin" && password == "password")
            {
                return await Task.FromResult<bool>(true);
            }
            else
            {
                return await Task.FromResult<bool>(false);
            }
        }

        public async Task<bool> RegisterUserAsync(string user)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> ResetPasswordAsync(string user)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> ForgotPasswordAsync(string user)
        {
            return await Task.FromResult<bool>(true);
        }

    }
}
