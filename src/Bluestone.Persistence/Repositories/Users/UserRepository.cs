using Bluestone.Domain.Entities.Users.ViewModels;
using Bluestone.Domain.Repositories.Users;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<GetUserDetailsByUserIdViewModel> GetUserDetailsByUserIdAsync(int userId)
        {
            string query = "bps_GetUserbyUserId";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);

            return await QueryFirstOrDefaultAsync<GetUserDetailsByUserIdViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }

        public async Task<GetUserDetailsByUsernameViewModel> GetUserDetailsByUsernameAsync(string username)
        {
            string query = "bps_GetUserbyUsername";

            DynamicParameters parameter = new();
            parameter.Add("@Username", username, DbType.String, ParameterDirection.Input);

            return await QueryFirstOrDefaultAsync<GetUserDetailsByUsernameViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }
        
    }
}
