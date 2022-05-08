using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.ConfigurationOptions;
using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.Models.Facility;
using Bluestone.Mobile.Domain.RequestProvider;
using Bluestone.Mobile.Domain.Services.Facility;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Application.Facility
{
    public class FacilityService : IFacilityService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public FacilityService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<FacilityModel>> GetAllFacilitiesAsync(string token)
        {
            var uri = WebServiceEndpoints.GetAllPatientsEndpoint;

            FacilityRoot messages = await _requestProvider.GetAsync<FacilityRoot>(uri, token);

            if (messages?.Data != null)
            {
                return messages?.Data.ToObservableCollection();
            }
            else
            {
                return new ObservableCollection<FacilityModel>();
            }
        }

        public async Task<FacilityModel> GetFacilityDetailsByIdAsync(int facilityId, string token)
        {
            var uri = WebServiceEndpoints.GetPatientInfoEndpoint + "/FacilityId=" + facilityId;

            FacilityModel facility;

            try
            {
                facility = await _requestProvider.GetAsync<FacilityModel>(uri, token);
            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound)
            {
                facility = null;
            }
            return facility;
        }

    }
}
