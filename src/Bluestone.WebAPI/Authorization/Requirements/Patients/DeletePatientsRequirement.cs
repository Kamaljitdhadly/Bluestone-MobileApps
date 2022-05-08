using Microsoft.AspNetCore.Authorization;

namespace Bluestone.WebAPI.Authorization.Requirements.Patients
{
    public class DeletePatientsRequirement : IAuthorizationRequirement
    {
        public string Action { get; set; }

        public string Feature { get; set; }
    }

    public class DeletePatientsRequirementHandler : AuthorizationHandler<DeletePatientsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DeletePatientsRequirement requirement)
        {
            var user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!context.User.HasClaim(f => f.Type == "Role" && f.Value == "AllowAccessToDeletePatients"))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
