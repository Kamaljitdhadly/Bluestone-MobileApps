using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.IDataStore
{
    public interface IPatientDataStore
    {
        Task<IEnumerable<PatientDataModel>> GetPatientsAsync();

        Task<PatientDataModel> GetPatient(int id);

        Task AddPatient(PatientDataModel Patient);

        Task UpdatePatient(PatientDataModel Patient);

        Task DeletePatient(PatientDataModel Patient);

    }
}
