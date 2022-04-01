using System.Threading.Tasks;

namespace Bluestone.Presentation.Services.FileShare
{
    public interface IFileShareService
    {
        Task ShareFileAsync(string filePath);
    }
}