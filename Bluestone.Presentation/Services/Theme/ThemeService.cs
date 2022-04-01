using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluestone.Presentation.Services.Theme
{
    public class ThemeService : IThemeService
    {
        public void SetTheme(int Theme)
        {
            switch (Theme)
            {
                case 0:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                case 1:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                case 2:
                    Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }

    }
}
