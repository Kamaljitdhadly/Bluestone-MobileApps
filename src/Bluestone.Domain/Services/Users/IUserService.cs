using Bluestone.Domain.Entities.Users.ViewModels;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Users
{
    public interface IUserService
    {
        Task<GetUserDetailsByUserIdViewModel> GetUserDetailsByUserIdAsync(int userId);
        Task<GetUserDetailsByUsernameViewModel> GetUserDetailsByUsernameAsync(string username);
    }
}
