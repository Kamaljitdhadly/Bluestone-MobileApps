using System.Data;
using System.Data.SqlClient;

namespace Bluestone.Persistence.ConnectionFactory
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}
