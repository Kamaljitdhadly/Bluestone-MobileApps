using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.Models.Patient;
using Bluestone.Mobile.Domain.Services.Patient;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Application.Patient
{
    public class PatientMockService : IPatientService
    {

        private readonly ObservableCollection<PatientModel> _mockPatient = new ObservableCollection<PatientModel>
        {
            new PatientModel
            {
                PatientId = 1,
                FirstName = ".NET Bot Black Hoodie 50% OFF",
                LastName = "Message Description 1",
                Email = "test@email.com",
                Phone = "555-555-5555"
            },
            new PatientModel
            {
                PatientId = 2,
                FirstName = ".NET Bot Black Hoodie 50% OFF",
                LastName = "Message Description 1",
                Email = "test@email.com",
                Phone = "555-555-5555"
            }
        };


        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public PatientMockService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<PatientModel>> GetAllPatientsAsync(string token)
        {
            return await Task.FromResult(_mockPatient);
        }


        public async Task<PatientModel> GetPatientInfoByIdAsync(int patientId, string token)
        {
            await Task.Delay(10);
            return _mockPatient.SingleOrDefault(c => c.PatientId == patientId);
        }

        public async Task<bool> CreatePatientAsync(PatientModel patient, string token)
        {
            return await Task.FromResult<bool>(false);
        }

        public async Task<bool> DeletePatientAsync(int patientId, string token)
        {
            return await Task.FromResult<bool>(false);
        }
    }
}
