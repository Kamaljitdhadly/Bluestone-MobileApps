using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Facilities
{
    public interface IFacilityRepository
    {
        Task<IEnumerable<GetFacilityListViewModel>> GetFacilityListAsync(GetFacilityListRequestModel request);
        Task<GetFacilityDetailsByIdViewModel> GetFacilityDetailsByIdAsync(int facilityId);
        Task<int> UpdateFacilityAsync(UpdateFacilityRequestModel facility);
        Task<int> InsertFacilityAsync(InsertFacilityRequestModel facility);
        Task<int> DeleteFacilityAsync(int facilityId);
    }
}
