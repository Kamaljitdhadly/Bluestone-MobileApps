using Bluestone.Domain.Entities.Patients.RequestModels;
using Bluestone.Domain.Entities.Patients.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Patients
{
    public interface IPatientService
    {
        Task<List<GetPatientListViewModel>> GetPatientListAsync(GetPatientListRequestModel request);
        Task<List<GetUserPatientListByNameViewModel>> GetUserPatientListByNameAsync(GetUserPatientListByNameRequestModel request);
    }
}
