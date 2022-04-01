using Bluestone.Presentation.Services.Theme;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bluestone.iOS.Services.Theme.ThemeService))]
namespace Bluestone.iOS.Services.Theme
{
    public class ThemeService : ITheme
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame)
                {
                    BackgroundColor = color.ToPlatformColor()
                };
                UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
            }
            else
            {
                var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
                if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = color.ToPlatformColor();
                }
            }
            var style = darkStatusBarTint ? UIStatusBarStyle.DarkContent : UIStatusBarStyle.LightContent;
            UIApplication.SharedApplication.SetStatusBarStyle(style, false);
            Platform.GetCurrentUIViewController()?.SetNeedsStatusBarAppearanceUpdate();
        }
    }
}