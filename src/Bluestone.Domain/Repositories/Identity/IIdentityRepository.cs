using Bluestone.Domain.Entities.Identity.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Identity
{
    public interface IIdentityRepository
    {
        Task<IEnumerable<string>> GetUserRolesAsync(GetUserRolesRequestModel request);
    }
}
