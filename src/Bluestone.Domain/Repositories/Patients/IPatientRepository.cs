using Bluestone.Domain.Entities.Patients.RequestModels;
using Bluestone.Domain.Entities.Patients.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Patients
{
    public interface IPatientRepository
    {
        Task<IEnumerable<GetPatientListViewModel>> GetPatientListAsync(GetPatientListRequestModel request);
        Task<IEnumerable<GetUserPatientListByNameViewModel>> GetUserPatientListByNameAsync(GetUserPatientListByNameRequestModel request);
    }
}
