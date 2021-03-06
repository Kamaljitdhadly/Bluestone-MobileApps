using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Xamarin.Forms.Application.Current.
                    MainPage.DisplayAlert(title, message, cancel);
        }

        public Task<string> DisplayPrompt(string title, string message)
        {
            return Xamarin.Forms.Application.Current
                    .MainPage.DisplayPromptAsync(title, message);
        }

        public Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons)
        {
            return Xamarin.Forms.Application.Current.
                MainPage.DisplayActionSheet(title, "Cancel", destruction, buttons);
        }
    }
}
