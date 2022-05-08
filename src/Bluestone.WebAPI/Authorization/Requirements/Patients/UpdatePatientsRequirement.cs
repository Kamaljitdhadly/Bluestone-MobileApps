using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Authorization.Requirements.Patients
{
    public class UpdatePatientsRequirement : IAuthorizationRequirement
    {
        public string Action { get; set; }

        public string Feature { get; set; }
    }

    public class UpdatePatientsRequirementHandler : AuthorizationHandler<UpdatePatientsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdatePatientsRequirement requirement)
        {
            var user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!context.User.HasClaim(f => f.Type == "Role" && f.Value == "AllowAccessToUpdatePatients"))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
