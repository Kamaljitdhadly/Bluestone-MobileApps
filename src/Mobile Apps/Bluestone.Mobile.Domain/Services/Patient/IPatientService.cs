using Bluestone.Mobile.Domain.Models.Patient;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.Services.Patient
{
    public interface IPatientService
    {
        Task<ObservableCollection<PatientModel>> GetAllPatientsAsync(string token);
        Task<PatientModel> GetPatientInfoByIdAsync(int patientId, string token);
        Task<bool> CreatePatientAsync(PatientModel patient, string token);
        Task<bool> DeletePatientAsync(int patientId, string token);

    }
}
