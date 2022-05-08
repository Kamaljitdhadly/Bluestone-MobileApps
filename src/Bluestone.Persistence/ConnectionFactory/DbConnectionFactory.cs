using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Bluestone.Persistence.ConnectionFactory
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        protected readonly IConfiguration Configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateOpenConnection()
        {
            return new SqlConnection(Configuration.GetSection("ConnectionStrings")["Bluestone"]);
        }
    }
}
