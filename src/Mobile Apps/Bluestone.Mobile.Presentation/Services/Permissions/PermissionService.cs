using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Presentation.Services.Permissions
{
    public static class PermissionService 
    {
        public async static Task<bool> RequestStorageAccess()
        {
            var currentStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission>();
            if (currentStatus != PermissionStatus.Granted)
            {
                var status = await CrossPermissions.Current.RequestPermissionAsync<StoragePermission>();
                return status == PermissionStatus.Granted;
            }
            else
            {
                return true;
            }
        }

        public async static Task<bool> RequestCameraAccess()
        {
            var currentStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();
            if (currentStatus != PermissionStatus.Granted)
            {
                var status = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
                return status == PermissionStatus.Granted;
            }
            else
            {
                return true;
            }
        }

        public async static Task<bool> RequestPhotosAccess()
        {
            var currentStatus = await CrossPermissions.Current.CheckPermissionStatusAsync<PhotosPermission>();
            if (currentStatus != PermissionStatus.Granted)
            {
                var status = await CrossPermissions.Current.RequestPermissionAsync<PhotosPermission>();
                return status == PermissionStatus.Granted;
            }
            else
            {
                return true;
            }
        }
    }
}
