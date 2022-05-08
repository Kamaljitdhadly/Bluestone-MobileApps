using System;

namespace Bluestone.Infrastructure.Web.Authorization.Policies
{
    public class AuthorizePolicyAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizePolicyAttribute(Type policy)
            : base(policy.FullName)
        {
        }
    }
}
