using Bluestone.Mobile.Domain.Models.Facility;
using Bluestone.Mobile.Domain.Models.Message;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.Services.Facility
{
    public interface IFacilityService
    {
        Task<ObservableCollection<FacilityModel>> GetAllFacilitiesAsync(string token);
        Task<FacilityModel> GetFacilityDetailsByIdAsync(int facilityId, string token);
    }
}
