using Bluestone.Core.ViewModels.Identity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bluestone.Core.Views.Identity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}