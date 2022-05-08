using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bluestone.Mobile.Presentation.Services.Theme
{
    public interface ITheme
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
