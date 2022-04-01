using Xamarin.Essentials;

namespace Bluestone.Presentation.Services.Preference
{
    public class PreferenceService : IPreferenceService
    {
        #region Setting Constants

        private const string AccessToken = "access_token";
        private const string FingerPrintEnabled = "FingerPrintEnabled";
        private const string FullScreen = "FullScreen";
        private const string ThemePreferance = "ThemePreferance";


        private readonly string AccessTokenDefault = string.Empty;
        private readonly bool FingerPrintDefault = false;
        private readonly bool FullScreenDefault = false;
        private readonly int ThemeDefault = 1;
        #endregion

        #region UserPreference Properties

        public string AuthAccessToken
        {
            get => Preferences.Get(AccessToken, AccessTokenDefault);
            set => Preferences.Set(AccessToken, value);
        }

        public bool IsFingerPrintEnabled
        {
            get => Preferences.Get(FingerPrintEnabled, FingerPrintDefault);
            set => Preferences.Set(FingerPrintEnabled, value);
        }


        public bool IsFullScreen
        {
            get => Preferences.Get(FullScreen, FullScreenDefault);
            set => Preferences.Set(FullScreen, value);
        }


        public int Theme
        {
            get => Preferences.Get(ThemePreferance, ThemeDefault);
            set => Preferences.Set(ThemePreferance, value);
        }

        #endregion
    }
}