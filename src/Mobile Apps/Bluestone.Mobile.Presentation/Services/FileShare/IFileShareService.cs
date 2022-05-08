using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.FileShare
{
    public interface IFileShareService
    {
        Task ShareFileAsync(string filePath);
    }
}