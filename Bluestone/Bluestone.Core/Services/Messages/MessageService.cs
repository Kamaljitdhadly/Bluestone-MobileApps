using Bluestone.Core.Services.RequestProvider;

namespace Bluestone.Core.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IRequestProvider _requestProvider;

        public MessageService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }
    }
}
