using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.Settings
{
    public interface ISettingsService
    {
        Task<FingerprintAuthenticationResult> FingerprintAuthenticationAsync(string title, string reason, string cancel = null, string fallback = null, string tooFast = null);
    }
}
