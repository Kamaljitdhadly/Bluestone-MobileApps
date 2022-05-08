using System;

namespace Bluestone.Mobile.Domain.ConfigurationOptions
{
    public static class AppSettings
    {

#if (DEVELOPMENT)

        public const string WebServiceUrl = "";
        public const string ClientId = "XXX-YYY-ZZZ";
        public const string ClientSecret = "secret";

#elif (TESTING)

        public const string WebServiceUrl = "";
        public const string ClientId = "XXX-YYY-ZZZ";
        public const string ClientSecret = "secret";

#elif (PRODUCTION)

        public const string WebServiceUrl = "";
        public const string ClientId = "XXX-YYY-ZZZ";
        public const string ClientSecret = "secret";

#endif

    }
}