using Bluestone.Domain.Entities.Identity.ViewModels;
using Bluestone.Domain.Services.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bluestone.Infrastructure.Web.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService, IConfiguration configuration)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            ValidateJwtTokenViewModel tokenmodel = jwtService.ValidateJwtToken(token,
                                                      configuration.GetSection("Jwt")["SigningKey"],
                                                      configuration.GetSection("Jwt")["Issuer"],
                                                      configuration.GetSection("Jwt")["Audience"]);

            if (tokenmodel != null)
            {
                // attach user to context on successful jwt validation
                var identity = new ClaimsIdentity(tokenmodel.Claims, "BasicAuthentication");
                context.User = new ClaimsPrincipal(identity);
            }

            await _next(context);
        }
    }
}
