using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.OpenUrl
{
    public interface IOpenUrlService
    {
        Task OpenUrl(string url);
    }
}
