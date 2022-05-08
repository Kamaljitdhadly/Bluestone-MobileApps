using Bluestone.Domain.Entities.Identity.RequestModels;
using Bluestone.Domain.Repositories.Identity;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Identity
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
    {
        public IdentityRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }



        public async Task<IEnumerable<string>> GetUserRolesAsync(GetUserRolesRequestModel request)
        {
            string query = "bps_UserRoles";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);

            return await QueryAsync<string>(query, parameter, null, CommandType.StoredProcedure);
        }


    }
}
