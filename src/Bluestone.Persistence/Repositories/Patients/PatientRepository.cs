using Bluestone.Domain.Entities.Patients.RequestModels;
using Bluestone.Domain.Entities.Patients.ViewModels;
using Bluestone.Domain.Repositories.Patients;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Base;
using Dapper;
using System.Data;

namespace Bluestone.Persistence.Repositories.Patients
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }


        public async Task<IEnumerable<GetPatientListViewModel>> GetPatientListAsync(GetPatientListRequestModel request)
        {
            string query = "BPS_PatientsList";

            DynamicParameters parameter = new();
            parameter.Add("@userId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@inactive", request.Inactive, DbType.Boolean, ParameterDirection.Input);
            parameter.Add("@PatientsAccessType", request.PatientsAccessType, DbType.Int32, ParameterDirection.Input);

            return await QueryAsync<GetPatientListViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetUserPatientListByNameViewModel>> GetUserPatientListByNameAsync(GetUserPatientListByNameRequestModel request)
        {
            string query = "bps_SearchUsersPatients";

            DynamicParameters parameter = new();
            parameter.Add("@UserId", request.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@SearchText", request.PatientName, DbType.String, ParameterDirection.Input);

            return await QueryAsync<GetUserPatientListByNameViewModel>(query, parameter, null, CommandType.StoredProcedure);
        }

    }
}
