using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bluestone.Mobile.Presentation.Services.FileShare
{
    public class FileShareService : IFileShareService
    {
        public Task ShareFileAsync(string filePath)
        {
            var shareFile = new ShareFile(filePath);
            var shareRequest = new ShareFileRequest(shareFile);

            return Share.RequestAsync(shareRequest);
        }
    }
}
