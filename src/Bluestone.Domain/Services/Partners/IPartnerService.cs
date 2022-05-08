using Bluestone.Domain.Entities.Partners.RequestModels;
using Bluestone.Domain.Entities.Partners.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Partners
{
    public interface IPartnerService
    {
        Task<List<GetPartnerListViewModel>> GetPartnerListAsync(GetPartnerListRequestModel request);
    }
}
