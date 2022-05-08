using Bluestone.Mobile.CrossCuttingConcerns.Extensions;
using Bluestone.Mobile.Domain.IDataStore;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bluestone.Mobile.Persistence.PatientStore
{
    public class PatientDataStore : IPatientDataStore
    {
        private readonly SQLiteAsyncConnection _connection;

        public PatientDataStore(Lazy<SQLiteAsyncConnection> lazyInitializer)
        {
            _connection = lazyInitializer.Value;
            InitializeAsync().SafeFireAndForget(false);
        }


        async Task InitializeAsync()
        {
            if (!_connection.TableMappings.Any(m => m.MappedType.Name == typeof(PatientDataModel).Name))
            {
                await _connection.CreateTableAsync(typeof(PatientDataModel)).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<PatientDataModel>> GetPatientsAsync()
        {
            return await _connection.Table<PatientDataModel>().ToListAsync();
        }

        public async Task DeletePatient(PatientDataModel Patient)
        {
            await _connection.DeleteAsync(Patient);
        }

        public async Task AddPatient(PatientDataModel Patient)
        {
            await _connection.InsertAsync(Patient);
        }

        public async Task UpdatePatient(PatientDataModel Patient)
        {
            await _connection.UpdateAsync(Patient);
        }

        public async Task<PatientDataModel> GetPatient(int id)
        {
            return await _connection.FindAsync<PatientDataModel>(id);
        }
    }
}
