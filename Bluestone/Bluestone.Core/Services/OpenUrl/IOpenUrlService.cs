using System.Threading.Tasks;

namespace Bluestone.Core.Services.OpenUrl
{
    public interface IOpenUrlService
    {
        Task OpenUrl(string url);
    }
}
