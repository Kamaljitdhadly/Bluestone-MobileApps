using Bluestone.Mobile.Domain.Models.Theme;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Mobile.Presentation.Services.Theme
{
    public class ThemeService : IThemeService
    {
        public void SetTheme(int Theme)
        {
            switch (Theme)
            {
                case (int)AppThemeEnum.System:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                case (int)AppThemeEnum.Light:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                case (int)AppThemeEnum.Dark:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }

    }
}
