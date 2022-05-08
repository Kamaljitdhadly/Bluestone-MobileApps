using System.Threading;
using System.Threading.Tasks;

namespace Bluestone.Domain.Infrastructure.Networking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);

        Task DownloadFileAsync(string url, string path, CancellationToken cancellationToken = default);
    }
}