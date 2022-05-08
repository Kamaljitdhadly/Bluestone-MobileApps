using Bluestone.Domain.Entities.Identity.RequestModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Identity
{
    public interface IIdentityService
    {
        bool ValidateUserPassword(string userPassword, string enteredPassword);
        Task<List<Claim>> GetUserRolesAsync(GetUserRolesRequestModel request);
    }
}
