using Bluestone.Mobile.Domain.Models.Message;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.Services.Message
{
    public interface IMessageService
    {
        Task<ObservableCollection<MessageModel>> GetInboxMessagesAsync(string token);
        Task<MessageModel> GetMessageDetailsByIdAsync(int messageId, string token);
    }
}
