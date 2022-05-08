using Bluestone.Infrastructure.Web.Authorization.Policies;
using Bluestone.WebAPI.Authorization.Requirements.Patients;
using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Authorization.Policies.Patients
{
    public class GetPatientsPolicy : IPolicy
    {
        public void Configure(AuthorizationPolicyBuilder policy)
        {
            policy.RequireAuthenticatedUser();
            policy.AddRequirements(new GetPatientsRequirement
            {
                Feature = "PatientManagement",
                Action = "Get",
            });
        }
    }


}
