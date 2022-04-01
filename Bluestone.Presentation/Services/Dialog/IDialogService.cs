using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.Dialog
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<string> DisplayPrompt(string title, string message);
        Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons);
    }
}
