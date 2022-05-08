using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.DeviceInfo
{
    public interface IDeviceInfoService
    {
        double PixelDensity { get; }

        double OSVersion { get; }

        Size GetScreenSize();
    }
}
