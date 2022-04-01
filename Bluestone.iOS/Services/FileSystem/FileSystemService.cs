using Bluestone.iOS.Services.FileSystem;
using Bluestone.Presentation.Services.FileSystem;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystemService))]

namespace Bluestone.iOS.Services.FileSystem
{
    public class FileSystemService : IFileSystemService
    {
        public string GetLocalFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }
    }
}