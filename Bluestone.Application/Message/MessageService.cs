using Bluestone.Application.RequestProvider;
using Bluestone.CrossCuttingConcerns.Extensions;
using Bluestone.Domain.ConfigurationOptions;
using Bluestone.Domain.IDataStore;
using Bluestone.Domain.Models.Message;
using Bluestone.Domain.Services.Message;
using Bluestone.Domain.Services.RequestProvider;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Application.Message
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
