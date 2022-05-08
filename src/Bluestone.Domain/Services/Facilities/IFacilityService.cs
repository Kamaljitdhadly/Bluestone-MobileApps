using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Facilities
{
    public interface IFacilityService
    {
        Task<List<GetFacilityListViewModel>> GetFacilityListAsync(GetFacilityListRequestModel request);
        Task<GetFacilityDetailsByIdViewModel> GetFacilityDetailsByIdAsync(int facilityId);
        Task<int> UpdateFacilityAsync(UpdateFacilityRequestModel facility);
        Task<int> InsertFacilityAsync(InsertFacilityRequestModel facility);
        Task DeleteFacilityAsync(int facilityId);
    }
}
