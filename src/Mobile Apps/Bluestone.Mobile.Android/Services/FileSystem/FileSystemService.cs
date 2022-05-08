using Bluestone.Droid.Services.FileSystem;
using Bluestone.Mobile.Presentation.Services.FileSystem;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystemService))]

namespace Bluestone.Droid.Services.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public string GetLocalFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}
