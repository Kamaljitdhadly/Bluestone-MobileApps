using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.Dialog
{
    public class ShellDialogService : IShellDialogService
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Shell.Current.DisplayAlert(title, message, cancel);
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return Shell.Current.DisplayAlert(title, message, accept, cancel);
        }

        public Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel)
        {
            return Shell.Current.DisplayPromptAsync(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheetAsync(string title, string destruction, params string[] buttons)
        {
            return await Shell.Current.DisplayActionSheet(title, "Cancel", destruction, buttons);
        }
    }
}
