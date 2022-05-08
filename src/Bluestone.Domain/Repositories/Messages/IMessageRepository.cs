using Bluestone.Domain.Entities.Messages.RequestModels;
using Bluestone.Domain.Entities.Messages.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Repositories.Messages
{
    public interface IMessageRepository
    {
        Task<IEnumerable<GetInboxMessageListViewModel>> GetInboxMessageListAsync(GetInboxMessageListRequestModel request);
        Task<GetMessageDetailsByIdViewModel> GetMessageDetailsByIdAsync(GetMessageDetailsByIdRequestModel request);
        Task<GetMessageHistoryViewModel> GetPatientMessageHistoryAsync(GetPatientMessageHistoryRequestModel request);
        Task<IEnumerable<GetMessageTypeListByUserViewModel>> GetMessageTypeListByUserAsync(GetMessageTypeListByUserRequestModel request);
    }
}
