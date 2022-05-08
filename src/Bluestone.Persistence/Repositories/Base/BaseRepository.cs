using Bluestone.Persistence.ConnectionFactory;
using Dapper;
using System.Data;


namespace Bluestone.Persistence.Repositories.Base
{
    public class BaseRepository
    {
        private readonly IDbConnectionFactory connectionFactory;

        protected BaseRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        protected async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection? conn = null)
        {
            if (conn != null) return await conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            else if (transaction != null) return await transaction.Connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);

            using (conn = connectionFactory.CreateOpenConnection())
            {
                conn.Open();
                return await conn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType)
                    .ConfigureAwait(false);
            }
        }

        protected async Task<T> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType commandType = CommandType.Text, IDbConnection? conn = null)
        {
            if (conn != null) return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
            else if (transaction != null) return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);

            using (conn = connectionFactory.CreateOpenConnection())
            {
                conn.Open();
                return await conn.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType)
                    .ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text)
        {
            if (transaction != null) return await transaction.Connection.QueryAsync<T>(sql, param, transaction, commandType: commandType);

            using (var conn = connectionFactory.CreateOpenConnection())
            {
                conn.Open();
                return await conn.QueryAsync<T>(sql, param, transaction, commandType: commandType)
                    .ConfigureAwait(false);
            }
        }


        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text)
        {
            if (transaction != null) return await transaction.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandType: commandType);

            using (var conn = connectionFactory.CreateOpenConnection())
            {
                conn.Open();
                return await conn.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandType: commandType)
                    .ConfigureAwait(false);
            }
        }


        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object? param = null, IDbTransaction? transaction = null, CommandType commandType = CommandType.Text)
        {
            if (transaction != null) return await transaction.Connection.QueryMultipleAsync(sql, param, transaction, commandType: commandType);

            SqlMapper.GridReader result;
            using (var conn = connectionFactory.CreateOpenConnection())
            {
                conn.Open();
                result = await conn.QueryMultipleAsync(sql, param, transaction, commandType: commandType)
                    .ConfigureAwait(false);
            }

            return result;
        }

    }
}