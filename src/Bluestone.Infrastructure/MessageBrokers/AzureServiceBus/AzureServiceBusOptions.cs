using System.Collections.Generic;

namespace Bluestone.Infrastructure.MessageBrokers.AzureServiceBus
{
    public class AzureServiceBusOptions
    {
        public string ConnectionString { get; set; }

        public Dictionary<string, string> QueueNames { get; set; }
    }
}
