using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.DataModels;
using Bluestone.Mobile.Domain.IDataStore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Persistence.DataStore
{
    public class Repository<T> : IRepository<T> where T : IDatabaseItem, new()
    {
        private readonly SQLiteAsyncConnection _connection;

        public Repository(Lazy<SQLiteAsyncConnection> lazyInitializer)
        {
            _connection = lazyInitializer.Value;
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!_connection.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                await _connection.CreateTableAsync(typeof(T)).ConfigureAwait(false);
            }
        }

        public Task<T> GetById(int id)
        {
            return _connection.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAsync(T item)
        {
            return _connection.DeleteAsync(item);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<int> SaveAsync(T item)
        {
            if (item.Id != 0)
            {
                return _connection.UpdateAsync(item);
            }
            else
            {
                return _connection.InsertAsync(item);
            }
        }
    }
}
