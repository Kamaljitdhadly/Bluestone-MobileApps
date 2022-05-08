using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.Dialog
{
    public interface IShellDialogService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task<string> DisplayPromptAsync(string title, string message, string accept, string cancel);
        Task<string> DisplayActionSheetAsync(string title, string destruction, params string[] buttons);
    }
}
