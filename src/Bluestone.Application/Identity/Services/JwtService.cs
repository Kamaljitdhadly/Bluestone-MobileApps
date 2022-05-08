using Bluestone.Domain.Entities.Identity.RequestModels;
using Bluestone.Domain.Entities.Identity.ViewModels;
using Bluestone.Domain.Services.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Bluestone.Application.Identity.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateJwtToken(JwtTokenRequestModel jwtInfo)
        {
            var claims = new[]
            {
                new Claim("UserId", jwtInfo.UserId.ToString()),
                new Claim("UserTypeId", jwtInfo.UserTypeId.ToString()),
                new Claim("UserName", jwtInfo.UserName),
                // this guarantees the token is unique
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (jwtInfo.AdditionalClaims is not null)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(jwtInfo.AdditionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwtInfo.Issuer,
                audience: jwtInfo.Audience,
                expires: DateTime.UtcNow.AddDays(jwtInfo.Expiration),
                claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }


        public ValidateJwtTokenViewModel ValidateJwtToken(string token, string signingKey, string issuer, string audience)
        {
            if (token == null)
                return null;

            ValidateJwtTokenViewModel tokenmodel = new();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(signingKey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                tokenmodel.Claims = jwtToken.Claims.ToList();

                // return user id from JWT token if validation successful
                return tokenmodel;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
