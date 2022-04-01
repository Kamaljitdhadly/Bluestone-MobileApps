using Bluestone.CrossCuttingConcerns.Extensions;
using Bluestone.Domain.ConfigurationOptions;
using Bluestone.Domain.IDataStore;
using Bluestone.Domain.Models.Identity;
using Bluestone.Domain.Models.Message;
using Bluestone.Domain.Models.Patient;
using Bluestone.Domain.Services.Message;
using Bluestone.Domain.Services.RequestProvider;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Bluestone.Application.Message
{
    public class MessageMockService : IMessageService
    {

        private readonly ObservableCollection<MessageModel> _mockMessage = new ObservableCollection<MessageModel>
        {
            new MessageModel
            {
                MessageId = 1,
                Subject = "Subject name",
                Body = "Message body details",
                InrIcon = false,
                IsRead = true,
                Urgent = true,
                MessageCssColor = "#000",
                How_Long = "25 min",
                Patient = new PatientModel
                {
                    PatientId = 1,
                    FirstName = "First name",
                    LastName = "Last Name",
                },
                MessageType = new MessageTypeModel
                {
                    MessageTypeId = 1,
                    MessageTypeName = "General message",
                    MessageDescription = "General message",
                },
                Sender = new UserModel
                {
                    UserId = 1,
                    FirstName = "user First Name",
                    LastName = "user last name"
                }
            },
            new MessageModel
            {
                MessageId = 2,
                Subject = "Subject name",
                Body = "Message body details",
                InrIcon = false,
                IsRead = true,
                Urgent = true,
                MessageCssColor = "#000",
                How_Long = "3 hr",
                Patient = new PatientModel
                {
                    PatientId = 2,
                    FirstName = "First name",
                    LastName = "Last Name",
                },
                MessageType = new MessageTypeModel
                {
                    MessageTypeId = 2,
                    MessageTypeName = "General message",
                    MessageDescription = "General message",
                },
                Sender = new UserModel
                {
                    UserId = 2,
                    FirstName = "user First Name",
                    LastName = "user last name"
                }
            },
        };

        private readonly IRequestProvider _requestProvider;
        private readonly IRepository<PatientDataModel> _repository;
        private readonly IPatientDataStore _patientStore;

        public MessageMockService(IRequestProvider requestProvider, IRepository<PatientDataModel> repository, IPatientDataStore patientStore)
        {
            _requestProvider = requestProvider;
            _patientStore = patientStore;
            _repository = repository;
        }

        public async Task<ObservableCollection<MessageModel>> GetInboxMessagesAsync(string token)
        {

            for (int i = 0; i < 100; i++)
            {
                _mockMessage.Add(new MessageModel
                {
                    MessageId = i + 2,
                    Subject = "Subject name",
                    Body = "Message body details",
                    InrIcon = false,
                    IsRead = true,
                    Urgent = true,
                    MessageCssColor = "#000",
                    How_Long = "3 hr",
                    Patient = new PatientModel
                    {
                        PatientId = i + 2,
                        FirstName = "First name",
                        LastName = "Last Name",
                    },
                    MessageType = new MessageTypeModel
                    {
                        MessageTypeId = i + 2,
                        MessageTypeName = "General message",
                        MessageDescription = "General message",
                    },
                    Sender = new UserModel
                    {
                        UserId = i + 2,
                        FirstName = "user First Name",
                        LastName = "user last name"
                    }
                });
            }
            
            
            return await Task.FromResult(_mockMessage);
        }

        public async Task<MessageModel> GetMessageDetailsByIdAsync(int messageId, string token)
        {
            await Task.Delay(10);
            return _mockMessage.SingleOrDefault(c => c.MessageId == messageId);
        }

    }
}
