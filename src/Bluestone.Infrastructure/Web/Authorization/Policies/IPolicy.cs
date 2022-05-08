using Microsoft.AspNetCore.Authorization;

namespace Bluestone.Infrastructure.Web.Authorization.Policies
{
    public interface IPolicy
    {
        void Configure(AuthorizationPolicyBuilder policy);
    }
}
