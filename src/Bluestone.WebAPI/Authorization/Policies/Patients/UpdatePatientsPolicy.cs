using Bluestone.Infrastructure.Web.Authorization.Policies;
using Bluestone.WebAPI.Authorization.Requirements.Patients;
using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Authorization.Policies.Patients
{
    public class UpdatePatientsPolicy : IPolicy
    {
        public void Configure(AuthorizationPolicyBuilder policy)
        {
            policy.RequireAuthenticatedUser();
            policy.AddRequirements(new UpdatePatientsRequirement
            {
                Feature = "PatientManagement",
                Action = "Set",
            });
        }
    }


}
