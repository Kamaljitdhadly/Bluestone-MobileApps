using System.IO;
using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.FileViewer
{
    public interface IFileViewerService
    {
        Task<bool> View(Stream stream, string filename);
    }
}
