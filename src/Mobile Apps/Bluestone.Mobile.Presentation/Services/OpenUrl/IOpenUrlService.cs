using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.OpenUrl
{
    public interface IOpenUrlService
    {
        Task OpenUrl(string url);
    }
}
