using AutoMapper;
using Bluestone.CrossCuttingConcerns.OS;
using Bluestone.Domain.Entities.Messages.RequestModels;
using Bluestone.Domain.Entities.Messages.ViewModels;
using Bluestone.Domain.Identity;
using Bluestone.Domain.Repositories.Messages;
using Bluestone.Domain.Services.Messages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bluestone.Application.Messages.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMessageRepository _messageRepository;

        public MessageService(
            IMapper mapper,
            ILogger<MessageService> logger,
            ICurrentUser currentUser,
            IDateTimeProvider dateTimeProvider,
            IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _currentUser = currentUser;
            _dateTimeProvider = dateTimeProvider;
            _messageRepository = messageRepository;
        }

        public async Task<List<GetInboxMessageListViewModel>> GetInboxMessageListAsync(GetInboxMessageListRequestModel request)
        {
            List<GetInboxMessageListViewModel> messages = (List<GetInboxMessageListViewModel>)await _messageRepository.GetInboxMessageListAsync(request);

            return messages;
        }

        public async Task<GetMessageDetailsByIdViewModel> GetMessageDetailsByIdAsync(GetMessageDetailsByIdRequestModel request)
        {
            var message = await _messageRepository.GetMessageDetailsByIdAsync(request);

            return message;
        }

        public async Task<List<GetPatientMessageHistoryViewModel>> GetPatientMessageHistoryAsync(GetPatientMessageHistoryRequestModel request)
        {
            var messageshistory = await _messageRepository.GetPatientMessageHistoryAsync(request);

            List<GetPatientMessageHistoryViewModel> messages = new();
            foreach (var item in messageshistory.Messages)
            {
                messages.Add(new GetPatientMessageHistoryViewModel()
                {
                    RowId = item.RowId,
                    Msgid = item.Msgid,
                    From = item.From,
                    Date = item.Date,
                    Message = item.Message,
                    Subject = item.From,
                    MsgCount = item.MsgCount,
                    HasOrder = item.HasOrder,
                    MessageCssColor = item.MessageCssColor,
                    Urgent = item.Urgent,
                    IsFaxNotification = item.IsFaxNotification,
                    MsgTypeId = item.MsgTypeId,
                    Typecode = item.Typecode,
                    Icon = "../../Content" + item.Icon,
                    StatusName = item.StatusName,
                    GeneralOrders = messageshistory.GeneralOrders.Where(s => s.MsgId == item.Msgid).ToList(),
                });
            }

            return messages;
        }

        public async Task<List<GetMessageTypeListByUserViewModel>> GetMessageTypeListByUserAsync(GetMessageTypeListByUserRequestModel request)
        {
            List<GetMessageTypeListByUserViewModel> messageTypes = (List<GetMessageTypeListByUserViewModel>)await _messageRepository.GetMessageTypeListByUserAsync(request);

            return messageTypes;
        }



    }
}
