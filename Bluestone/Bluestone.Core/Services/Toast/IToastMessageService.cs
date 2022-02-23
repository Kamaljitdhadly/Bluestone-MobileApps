using Xamarin.Forms;

namespace Bluestone.Core.Services.Toast
{
    public interface IToastMessageService
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
