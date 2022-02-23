using System.Globalization;
namespace Bluestone.Core.Helpers
{
    public interface ILocalizeHelper
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
