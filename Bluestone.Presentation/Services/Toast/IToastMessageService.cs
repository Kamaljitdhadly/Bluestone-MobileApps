using Xamarin.Forms;

namespace Bluestone.Presentation.Services.Toast
{
    public interface IToastMessageService
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
