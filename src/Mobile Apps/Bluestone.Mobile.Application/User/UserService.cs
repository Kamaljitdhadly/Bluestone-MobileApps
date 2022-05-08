using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.ConfigurationOptions;
using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.Models.User;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using Bluestone.Mobile.Domain.Services.User;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Bluestone.Mobile.Application.User
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public UserService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }


        public async Task<ObservableCollection<PatientCareTeamModel>> GetPatientCareTeamAsync(string token)
        {
            var uri = WebServiceEndpoints.GetAllPatientsEndpoint;

            IEnumerable<PatientCareTeamModel> careTeamMembers = await _requestProvider.GetAsync<IEnumerable<PatientCareTeamModel>>(uri, token);

            if (careTeamMembers != null)
            {
                return careTeamMembers?.ToObservableCollection();
            }
            else
            {
                return new ObservableCollection<PatientCareTeamModel>();
            }
        }

    }
}
