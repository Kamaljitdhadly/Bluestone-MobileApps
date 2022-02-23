using Xamarin.Forms;

namespace Bluestone.Core.Services.DeviceInfo
{
    public interface IDeviceInfoService
    {
        double PixelDensity { get; }

        double OSVersion { get; }

        Size GetScreenSize();
    }
}
