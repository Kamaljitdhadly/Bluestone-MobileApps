using Bluestone.Domain.Entities.Identity.RequestModels;
using Bluestone.Domain.Entities.Identity.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bluestone.Domain.Services.Identity
{
    public interface IJwtService
    {
        public string GenerateJwtToken(JwtTokenRequestModel jwtInfo);
        public ValidateJwtTokenViewModel ValidateJwtToken(string token, string signingKey, string issuer, string audience);
    }
}
