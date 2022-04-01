using Bluestone.Presentation.GlobalSettings;
using System;
using Xamarin.Forms;


namespace Bluestone.Presentation.AppLayout
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            AppRouting.RegisterRoute();
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//" + AppRoutingConstants.LoginPageRoute);
        }


    }
}