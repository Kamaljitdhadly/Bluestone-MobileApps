using Bluestone.Application.RequestProvider;
using Bluestone.CrossCuttingConcerns.Extensions;
using Bluestone.Domain.ConfigurationOptions;
using Bluestone.Domain.IDataStore;
using Bluestone.Domain.Models.Patient;
using Bluestone.Domain.Services.Patient;
using Bluestone.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Application.Patient
{
    public class PatientService : IPatientService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public PatientService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<PatientModel>> GetAllPatientsAsync(string token)
        {
            var uri = WebServiceEndpoints.GetAllPatientsEndpoint;

            PatientRoot patients = await _requestProvider.GetAsync<PatientRoot>(uri, token);

            if (patients?.Data != null)
            {
                return patients?.Data.ToObservableCollection();
            }
            else
            {
                return new ObservableCollection<PatientModel>();
            }
        }

        public async Task<PatientModel> GetPatientInfoByIdAsync(int patientId, string token)
        {
            var uri = WebServiceEndpoints.GetPatientInfoEndpoint + "/PatientId=" + patientId;

            PatientModel patient;

            try
            {
                patient = await _requestProvider.GetAsync<PatientModel>(uri, token);
            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound)
            {
                patient = null;
            }
            return patient;
        }

        public async Task<bool> CreatePatientAsync(PatientModel patient, string token)
        {
            var uri = WebServiceEndpoints.CreatePatientEndpoint;

            var createPatientCommand = new CreatePatientCommand(patient.PatientId, patient.FirstName, patient.LastName, patient.Phone, patient.Email);

            try
            {
                var result = await _requestProvider.PostAsync(uri, createPatientCommand, token);
            }
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePatientAsync(int patientId, string token)
        {
            var uri = WebServiceEndpoints.DeletePatientEndpoint;

            var deletePatientCommand = new DeletePatientCommand(patientId);

            try
            {
                var result = await _requestProvider.PostAsync(uri, deletePatientCommand, token);
            }
            catch (HttpRequestExceptionEx ex) when (ex.HttpCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return false;
            }

            return true;
        }

    }
}
