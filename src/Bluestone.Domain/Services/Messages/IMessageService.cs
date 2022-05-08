using Bluestone.Domain.Entities.Messages.RequestModels;
using Bluestone.Domain.Entities.Messages.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Domain.Services.Messages
{
    public interface IMessageService
    {
        Task<List<GetInboxMessageListViewModel>> GetInboxMessageListAsync(GetInboxMessageListRequestModel request);
        Task<GetMessageDetailsByIdViewModel> GetMessageDetailsByIdAsync(GetMessageDetailsByIdRequestModel request);
        Task<List<GetPatientMessageHistoryViewModel>> GetPatientMessageHistoryAsync(GetPatientMessageHistoryRequestModel request);
        Task<List<GetMessageTypeListByUserViewModel>> GetMessageTypeListByUserAsync(GetMessageTypeListByUserRequestModel request);
    }
}
