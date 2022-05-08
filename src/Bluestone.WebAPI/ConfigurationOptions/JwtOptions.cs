using CryptographyHelper.Certificates;

namespace Bluestone.WebAPI.ConfigurationOptions
{
    public class JwtOptions
    {
        public string SigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double Expiration { get; set; }
    }
}
