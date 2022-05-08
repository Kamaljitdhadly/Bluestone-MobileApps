using Bluestone.Domain.Repositories.Facilities;
using Bluestone.Domain.Repositories.Identity;
using Bluestone.Domain.Repositories.Messages;
using Bluestone.Domain.Repositories.Partners;
using Bluestone.Domain.Repositories.Patients;
using Bluestone.Domain.Repositories.Users;
using Bluestone.Persistence.ConnectionFactory;
using Bluestone.Persistence.Repositories.Facilities;
using Bluestone.Persistence.Repositories.Identity;
using Bluestone.Persistence.Repositories.Messages;
using Bluestone.Persistence.Repositories.Partners;
using Bluestone.Persistence.Repositories.Patients;
using Bluestone.Persistence.Repositories.Users;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddScoped(typeof(IDbConnectionFactory), typeof(DbConnectionFactory))
                    .AddScoped(typeof(IIdentityRepository), typeof(IdentityRepository))
                    .AddScoped(typeof(IFacilityRepository), typeof(FacilityRepository))
                    .AddScoped(typeof(IMessageRepository), typeof(MessageRepository))
                    .AddScoped(typeof(IPartnerRepository), typeof(PartnerRepository))
                    .AddScoped(typeof(IPatientRepository), typeof(PatientRepository))
                    .AddScoped(typeof(IUserRepository), typeof(UserRepository));
            return services;
        }
    }
}
