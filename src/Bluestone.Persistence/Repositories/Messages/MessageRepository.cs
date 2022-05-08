using Bluestone.Domain.Entities.Messages.RequestModels;
using Bluestone.Domain.Entities.Messages.ViewModels;
using Bluestone.Domain.Repositories.Messages;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Messages
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<IEnumerable<GetInboxMessageListViewModel>> GetInboxMessageListAsync(GetInboxMessageListRequestModel request)
        {
            string query = "bps_GetUserInbox";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@Status", request.Status, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PageNo", request.PageNo, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PatientId", request.PatientId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@TStamp", request.TStamp, DbType.DateTime, ParameterDirection.Input);
            parameter.Add("@ViewId", request.ViewId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@HavingOrdersAttached", request.HavingOrdersAttached, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@UrgentOnly", request.UrgentOnly, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@TeamId", request.TeamId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@SortBy", request.SortBy, DbType.String, ParameterDirection.Input);
            parameter.Add("@FilterInbox", request.FilterInbox, DbType.String, ParameterDirection.Input);
            parameter.Add("@IsCommunitySearch", request.IsCommunitySearch, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@IncludeFiledSystemMessages", request.IncludeFiledSystemMessages, DbType.Boolean, ParameterDirection.Input);

            return await QueryAsync<GetInboxMessageListViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }


        public async Task<GetMessageDetailsByIdViewModel> GetMessageDetailsByIdAsync(GetMessageDetailsByIdRequestModel request)
        {
            string query = "bps_GetMessageById";

            DynamicParameters parameter = new();
            parameter.Add("@MessageId", request.MessageId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@SentToUserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@IsSentViewMessage", !request.ToolBarOption, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@userTimeZone", request.UserTimezone, DbType.Int32, ParameterDirection.Input);

            return await ExecuteScalarAsync<GetMessageDetailsByIdViewModel>(query, parameter, null, null, CommandType.StoredProcedure, null);
        }


        public async Task<GetMessageHistoryViewModel> GetPatientMessageHistoryAsync(GetPatientMessageHistoryRequestModel request)
        {
            string query = "bps_GetPatientMessageHistoryByPaging";

            DynamicParameters parameter = new();
            parameter.Add("@PatientId", request.PatientId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@MsgId", request.MsgId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PageNo", request.PageNumber, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@UserTimeZone", request.UserTimeZone, DbType.Int32, ParameterDirection.Input);

            var messages = await QueryMultipleAsync(query, parameter, null, CommandType.StoredProcedure);

            GetMessageHistoryViewModel messageshistory = new();
            messageshistory.Messages = messages.Read<PatientMessagesHistory>().ToList();
            messageshistory.GeneralOrders = messages.Read<PatientMessagesHistoryGeneralOrder>().ToList();

            return messageshistory;
        }
        

        public async Task<IEnumerable<GetMessageTypeListByUserViewModel>> GetMessageTypeListByUserAsync(GetMessageTypeListByUserRequestModel request)
        {
            string query = "api_getMessageTypelistByUser";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@PatientId", request.PatientId, DbType.Int32, ParameterDirection.Input);

            return await QueryAsync<GetMessageTypeListByUserViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }


    }
}
