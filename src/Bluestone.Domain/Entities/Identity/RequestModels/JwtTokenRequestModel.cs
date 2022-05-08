using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bluestone.Domain.Entities.Identity.RequestModels
{
    public class JwtTokenRequestModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double Expiration { get; set; }
        public List<Claim> AdditionalClaims { get; set; }


        public JwtTokenRequestModel(int userId, string userName, int userTypeId, string signingKey, string issuer, string audience, double expiration, List<Claim> additionalClaims)
        {
            UserId = userId;
            UserName = userName;
            UserTypeId = userTypeId;
            SigningKey = signingKey;
            Issuer = issuer;
            Audience = audience;
            Expiration = expiration;
            AdditionalClaims = additionalClaims;
        }
    }
}
