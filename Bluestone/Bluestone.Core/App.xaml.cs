using Bluestone.Core.DataServices;
using Bluestone.Core.AppLayout;
using Xamarin.Forms;
using Bluestone.Core.GlobalSettings;

namespace Bluestone
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Dependencies.Register();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
