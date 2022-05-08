using Bluestone.Mobile.Domain.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Domain.IDataStore
{
    public interface IRepository<T> where T : IDatabaseItem, new()
    {
        Task<T> GetById(int id);
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
    }
}
