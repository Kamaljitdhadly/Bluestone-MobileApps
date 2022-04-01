using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.Preference
{
    public interface IPreferenceService
    {
        string AuthAccessToken { get; set; }
        bool IsFingerPrintEnabled { get; set; }
        bool IsFullScreen { get; set; }
        int Theme { get; set; }
    }
}
