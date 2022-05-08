using Bluestone.Domain.Entities.Partners.RequestModels;
using Bluestone.Domain.Entities.Partners.ViewModels;
using Bluestone.Domain.Repositories.Partners;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Partners
{
    public class PartnerRepository : BaseRepository, IPartnerRepository
    {
        public PartnerRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<IEnumerable<GetPartnerListViewModel>> GetPartnerListAsync(GetPartnerListRequestModel request)
        {
            string query = "bps_GetActivePartners";

            DynamicParameters parameter = new();
            parameter.Add("@IsActive", request.IsActive, DbType.Boolean, ParameterDirection.Input);

            return await QueryAsync<GetPartnerListViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }


    }
}
