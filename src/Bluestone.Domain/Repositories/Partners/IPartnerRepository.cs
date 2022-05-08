using Bluestone.Domain.Entities.Partners.RequestModels;
using Bluestone.Domain.Entities.Partners.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Partners
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<GetPartnerListViewModel>> GetPartnerListAsync(GetPartnerListRequestModel request);
    }
}
