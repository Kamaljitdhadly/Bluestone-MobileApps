using SQLite;
using System;
using System.IO;

namespace Bluestone.Mobile.Persistence.DataConnection
{
    public static class DataConnection
    {
        public static Lazy<SQLiteAsyncConnection> GetConnection()
        {
            return new Lazy<SQLiteAsyncConnection>(() =>
            {
                return new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            });
        }
    }
}
