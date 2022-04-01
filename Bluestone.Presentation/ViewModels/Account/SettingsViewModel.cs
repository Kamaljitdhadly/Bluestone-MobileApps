using Bluestone.Presentation.Services.Settings;
using Bluestone.Presentation.Services.Theme;
using Bluestone.Presentation.ViewModels.Base;
using Bluestone.Domain.Models.Theme;
using Plugin.Fingerprint.Abstractions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bluestone.Presentation.ViewModels.Account
{
    public class SettingsViewModel : ViewModelBase
    {
        private bool _isBiometric = false;
        private bool _isFullScreen = false;
        private bool _isLightTheme = false;
        private string _fingerPrintErrors = "";

        private readonly ISettingsService _settingsService;
        private readonly IThemeService _themeService;

        public SettingsViewModel()
        {
            _settingsService = DependencyService.Get<ISettingsService>();
            _themeService = DependencyService.Get<IThemeService>();
        }

        public bool IsBiometric
        {
            get => _isBiometric;
            set
            {
                _isBiometric = value;
                RaisePropertyChanged(() => IsBiometric);
            }
        }

        public bool IsFullScreen
        {
            get => _isFullScreen;
            set
            {
                _isFullScreen = value;
                RaisePropertyChanged(() => IsFullScreen);
            }
        }

        public bool IsLightTheme
        {
            get => _isLightTheme;
            set
            {
                _isLightTheme = value;
                RaisePropertyChanged(() => IsLightTheme);
            }
        }

        public string FingerPrintErrors
        {
            get => _fingerPrintErrors;
            set
            {
                _fingerPrintErrors = value;
                RaisePropertyChanged(() => FingerPrintErrors);
            }
        }


        public ICommand BiometricCommand => new Command(async () => await ActivateBiometricAuthenticationAsync());
        public ICommand FullScreenCommand => new Command(async () => await FullScreenChangedAsync());
        public ICommand SystemThemeCommand => new Command<CheckedChangedEventArgs>((item) => RequestedThemeChangedAsync(item, (int)AppTheme.System));
        public ICommand LightThemeCommand => new Command<CheckedChangedEventArgs>((item) => RequestedThemeChangedAsync(item, (int)AppTheme.Light));
        public ICommand DarkThemeCommand => new Command<CheckedChangedEventArgs>((item) => RequestedThemeChangedAsync(item, (int)AppTheme.Dark));

        private async Task ActivateBiometricAuthenticationAsync()
        {
            FingerprintAuthenticationResult result = await _settingsService.FingerprintAuthenticationAsync("Login to Bluestone", "Biometric Authentication");

            if (result.Authenticated)
            {
                PreferenceService.IsFingerPrintEnabled = true;
            }
            else
            {
                FingerPrintErrors = $"{result.Status}: {result.ErrorMessage}";
            }
        }

        private void RequestedThemeChangedAsync(CheckedChangedEventArgs sender, int Theme)
        {
            bool IsChecked = sender.Value;
            if (IsChecked)
            {
                PreferenceService.Theme = Theme;
                _themeService.SetTheme(Theme);
            }
        }

        private async Task FullScreenChangedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
