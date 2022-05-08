using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.ConfigurationOptions;
using Bluestone.Mobile.Domain.IDataStore;
using Bluestone.Mobile.Domain.Models.Message;
using Bluestone.Mobile.Domain.RequestProvider;
using Bluestone.Mobile.Domain.Services.Message;
using Bluestone.Mobile.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Application.Message
{
    public class MessageService : IMessageService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public MessageService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<MessageModel>> GetInboxMessagesAsync(string token)
        {
            var uri = WebServiceEndpoints.GetAllPatientsEndpoint;

            MessageRoot messages = await _requestProvider.GetAsync<MessageRoot>(uri, token);

            if (messages?.Data != null)
            {
                return messages?.Data.ToObservableCollection();
            }
            else
            {
                return new ObservableCollection<MessageModel>();
            }
        }

        public async Task<MessageModel> GetMessageDetailsByIdAsync(int messageId, string token)
        {
            var uri = WebServiceEndpoints.GetPatientInfoEndpoint + "/MessageId=" + messageId;

            MessageModel message;

            try
            {
                message = await _requestProvider.GetAsync<MessageModel>(uri, token);
            }
            catch (HttpRequestExceptionEx exception) when (exception.HttpCode == System.Net.HttpStatusCode.NotFound)
            {
                message = null;
            }
            return message;
        }

    }
}
