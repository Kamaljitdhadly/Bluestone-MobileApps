using System.IO;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.FileViewer
{
    public interface IFileViewerService
    {
        Task<bool> View(Stream stream, string filename);
    }
}
