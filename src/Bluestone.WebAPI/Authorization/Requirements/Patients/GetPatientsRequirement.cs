using Bluestone.CrossCuttingConcerns.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Bluestone.WebAPI.Authorization.Requirements.Patients
{
    public class GetPatientsRequirement : IAuthorizationRequirement
    {
        public string Action { get; set; }

        public string Feature { get; set; }
    }

    public class GetPatientsRequirementHandler : AuthorizationHandler<GetPatientsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GetPatientsRequirement requirement)
        {
            var user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!context.User.HasClaim(f => f.Type == ClaimTypes.Role && f.Value == ConstantsHelper.Roles.AllowAllPatientView))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
