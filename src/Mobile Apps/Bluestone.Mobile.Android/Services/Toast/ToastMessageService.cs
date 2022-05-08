using Android.Graphics;
using Android.Widget;
using Bluestone.Droid.Services.Toast;
using Bluestone.Mobile.Presentation.Services.DeviceInfo;
using Bluestone.Mobile.Presentation.Services.Toast;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: Dependency(typeof(ToastMessageService))]
namespace Bluestone.Droid.Services.Toast
{
    public class ToastMessageService : IToastMessageService
    {
        private const string DefaultBackgroundColorLight = "#1d1d1e";
        private const string DefaultBackgroundColorDark = "#373737";

        [System.Obsolete]
        public void LongAlert(string message)
        {
            var toast = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long);

            var backgroundColor = Xamarin.Forms.Application.Current.RequestedTheme == OSAppTheme.Dark
                ? DefaultBackgroundColorDark
                : DefaultBackgroundColorLight;
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
            {
                toast.View.Background.SetColorFilter(new BlendModeColorFilter(Color.FromHex(backgroundColor).ToAndroid(), BlendMode.SrcIn));
            }
            else
            {
                toast.View.Background.SetColorFilter(Color.FromHex(backgroundColor).ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
            }

            var textView = toast.View.FindViewById<TextView>(Android.Resource.Id.Message);
            textView.SetTextColor(Color.White.ToAndroid());

            var deviceInfoService = DependencyService.Get<IDeviceInfoService>();
            var pixelDensity = (int)deviceInfoService.PixelDensity;

            toast.SetGravity(Android.Views.GravityFlags.Bottom | Android.Views.GravityFlags.CenterHorizontal, 0, 100 * pixelDensity);

            toast.Show();
        }

        [System.Obsolete]
        public void ShortAlert(string message)
        {
            var toast = Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short);

            // On API Level 30+ only simple toast messages can be displayed. No customizations to the toast background and view are permitted: https://developer.android.com/reference/android/widget/Toast#getView()
            if (Android.OS.Build.VERSION.SdkInt <= Android.OS.BuildVersionCodes.Q)
            {
                var backgroundColor = Xamarin.Forms.Application.Current.RequestedTheme == OSAppTheme.Dark
                  ? DefaultBackgroundColorDark
                  : DefaultBackgroundColorLight;
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Q)
                {
                    toast.View.Background.SetColorFilter(new BlendModeColorFilter(Color.FromHex(backgroundColor).ToAndroid(), BlendMode.SrcIn));
                }
                else
                {
                    toast.View.Background.SetColorFilter(Color.FromHex(backgroundColor).ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
                }

                var textView = toast.View.FindViewById<TextView>(Android.Resource.Id.Message);
                textView.SetTextColor(Color.White.ToAndroid());
            }

            var deviceInfoService = DependencyService.Get<IDeviceInfoService>();
            var pixelDensity = (int)deviceInfoService.PixelDensity;

            toast.SetGravity(Android.Views.GravityFlags.Bottom | Android.Views.GravityFlags.CenterHorizontal, 0, 100 * pixelDensity);

            toast.Show();
        }
    }
}