using Bluestone.Mobile.Presentation.AppLayout;
using Bluestone.Mobile.Presentation.GlobalSettings;
using Bluestone.Mobile.Presentation.Services.Navigation;
using Bluestone.Mobile.Presentation.Services.Preference;
using Bluestone.Mobile.Presentation.Services.Theme;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bluestone
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();
            Dependencies.Register();

            MainPage = new AppShell();
            InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = DependencyService.Get<IShellNavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
            base.OnStart();
            OnResume();
        }

        protected override void OnSleep()
        {
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            RequestedThemeChanged += App_RequestedThemeChanged;
            InitTheme();
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SetStatusBar();
            });
        }

        private void InitTheme()
        {
            var themeService = DependencyService.Get<IThemeService>();
            var preferanceService = DependencyService.Get<IPreferenceService>();
            themeService.SetTheme(preferanceService.Theme);
        }

        void SetStatusBar()
        {
            var nav = Current.MainPage as NavigationPage;

            var e = DependencyService.Get<ITheme>();
            if (Current.RequestedTheme == OSAppTheme.Dark)
            {
                e?.SetStatusBarColor(Color.FromHex("#222222"), false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("#222222");
                    nav.BarTextColor = Color.White;
                }
            }
            else
            {
                e?.SetStatusBarColor(Color.FromHex("#2B7DE9"), true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = Color.FromHex("#2B7DE9");
                    nav.BarTextColor = Color.White;
                }
            }
        }
    }
}
