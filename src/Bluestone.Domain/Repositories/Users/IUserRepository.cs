using Bluestone.Domain.Entities.Users.ViewModels;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Users
{
    public interface IUserRepository
    {
        Task<GetUserDetailsByUserIdViewModel> GetUserDetailsByUserIdAsync(int userId);
        Task<GetUserDetailsByUsernameViewModel> GetUserDetailsByUsernameAsync(string username);
    }
}
