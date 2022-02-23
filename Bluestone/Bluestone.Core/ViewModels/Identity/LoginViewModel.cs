using Bluestone.Core.ViewModels.Base;
using Bluestone.Core.Views.Dashboard;
using Xamarin.Forms;

namespace Bluestone.Core.ViewModels.Identity
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
