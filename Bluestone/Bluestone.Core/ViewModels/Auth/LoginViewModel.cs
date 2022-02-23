using Bluestone.Core.ViewModels.Base;
using Bluestone.Core.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Auth
{
    public class LoginViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
