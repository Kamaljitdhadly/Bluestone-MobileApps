using Bluestone.Core.AppLayout.Settings;
using Bluestone.Core.Models.Token;
using Bluestone.Core.Services.RequestProvider;
using System.Net;
using System.Threading.Tasks;

namespace Bluestone.Core.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IRequestProvider _requestProvider;
        private string _codeVerifier = "";

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
                GlobalSettings.Instance.LogoutEndpoint,
                token,
                GlobalSettings.Instance.LogoutCallback);
        }

        public async Task<UserToken> GetTokenAsync(string code)
        {
            string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}", code, WebUtility.UrlEncode(GlobalSettings.Instance.Callback), _codeVerifier);
            var token = await _requestProvider.PostAsync<UserToken>(GlobalSettings.Instance.TokenEndpoint, data, GlobalSettings.Instance.ClientId, GlobalSettings.Instance.ClientSecret);
            return token;
        }

    }
}
