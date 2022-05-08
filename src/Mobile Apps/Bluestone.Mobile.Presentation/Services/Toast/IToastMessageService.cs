using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.Toast
{
    public interface IToastMessageService
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
