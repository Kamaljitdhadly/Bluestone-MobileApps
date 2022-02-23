using System.Drawing;

namespace Bluestone.Core.Services.Theme
{
    public interface ITheme
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
