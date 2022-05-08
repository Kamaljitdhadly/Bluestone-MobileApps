using System.Globalization;
using System.Threading;

namespace Bluestone.Mobile.CrossCuttingConcerns.Helpers
{
    public class LocalizeHelper 
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo("en");
        }

        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
