using Bluestone.Infrastructure.Caching;
using Bluestone.Infrastructure.Interceptors;
using Bluestone.Infrastructure.Logging;
using Bluestone.Infrastructure.MessageBrokers;
using Bluestone.Infrastructure.Monitoring;
using Bluestone.Infrastructure.Storages;
using System.Collections.Generic;

namespace Bluestone.WebAPI.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public LoggingOptions Logging { get; set; }

        public CachingOptions Caching { get; set; }

        public MonitoringOptions Monitoring { get; set; }

        public IdentityServerAuthentication IdentityServerAuthentication { get; set; }

        public string AllowedHosts { get; set; }

        public CORS CORS { get; set; }

        public JwtOptions Jwt { get; set; }

        public StorageOptions Storage { get; set; }

        public MessageBrokerOptions MessageBroker { get; set; }

        public Dictionary<string, string> SecurityHeaders { get; set; }

        public InterceptorsOptions Interceptors { get; set; }

        public CertificatesOptions Certificates { get; set; }
    }
}
