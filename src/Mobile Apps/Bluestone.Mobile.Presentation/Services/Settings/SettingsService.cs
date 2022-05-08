using Bluestone.Mobile.Domain.Services.RequestProvider;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IRequestProvider _requestProvider;

        public SettingsService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<FingerprintAuthenticationResult> FingerprintAuthenticationAsync(string title, string reason, string cancel = null, string fallback = null, string tooFast = null)
        {
            CancellationTokenSource  _cancel = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            var dialogConfig = new AuthenticationRequestConfiguration(title, reason)
            { // all optional
                CancelTitle = cancel,
                FallbackTitle = fallback,
                AllowAlternativeAuthentication = true,
                ConfirmationRequired = true
            };

            // optional
            dialogConfig.HelpTexts.MovedTooFast = tooFast;

            return await CrossFingerprint.Current.AuthenticateAsync(dialogConfig, _cancel.Token);
        }

    }
}
