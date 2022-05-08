using Bluestone.Domain.Entities.Facilities.RequestModels;
using Bluestone.Domain.Entities.Facilities.ViewModels;
using Bluestone.Domain.Repositories.Facilities;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Facilities
{
    public class FacilityRepository : BaseRepository, IFacilityRepository
    {
        public FacilityRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<IEnumerable<GetFacilityListViewModel>> GetFacilityListAsync(GetFacilityListRequestModel request)
        {
            string query = "api_getFacilityListByUserId";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@InActive", request.InActive, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@FacilityAccessType", request.FacilityAccessType, DbType.Int32, ParameterDirection.Input);

            return await QueryAsync<GetFacilityListViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }


        public async Task<GetFacilityDetailsByIdViewModel> GetFacilityDetailsByIdAsync(int facilityId)
        {
            string query = "bps_getfacilitydetailsbyId";

            DynamicParameters parameter = new();
            parameter.Add("@facilityId", facilityId, DbType.Int32, ParameterDirection.Input);

            return await ExecuteScalarAsync<GetFacilityDetailsByIdViewModel>(query, parameter, null, null, CommandType.StoredProcedure, null);
        }

        public async Task<int> UpdateFacilityAsync(UpdateFacilityRequestModel facility)
        {
            string query = "bps_updatefacility";

            DynamicParameters parameter = new();
            parameter.Add("@facilityId", facility.FacilityId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", facility.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", facility.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@City", facility.City, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", facility.Address, DbType.String, ParameterDirection.Input);

            return await ExecuteAsync(query, parameter, null, null, CommandType.StoredProcedure, null);
        }

        public async Task<int> InsertFacilityAsync(InsertFacilityRequestModel facility)
        {
            string query = "bps_insertfacility";

            DynamicParameters parameter = new();
            parameter.Add("@facilityId", facility.FacilityId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", facility.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", facility.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@City", facility.City, DbType.String, ParameterDirection.Input);
            parameter.Add("@Address", facility.Address, DbType.String, ParameterDirection.Input);

            return await ExecuteAsync(query, parameter, null, null, CommandType.StoredProcedure, null);
        }

        public async Task<int> DeleteFacilityAsync(int facilityId)
        {
            string query = "bps_deletefacility";

            DynamicParameters parameter = new();
            parameter.Add("@facilityId", facilityId, DbType.Int32, ParameterDirection.Input);

            return await ExecuteAsync(query, parameter, null, null, CommandType.StoredProcedure, null);
        }

    }
}
