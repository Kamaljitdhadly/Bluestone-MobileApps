using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Core.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return Application.Current.MainPage.DisplayAlert (title, message, buttonLabel);
        }
    }
}
