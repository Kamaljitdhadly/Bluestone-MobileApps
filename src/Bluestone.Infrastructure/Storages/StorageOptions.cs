using Bluestone.Infrastructure.Storages.Amazon;
using Bluestone.Infrastructure.Storages.Azure;
using Bluestone.Infrastructure.Storages.Local;

namespace Bluestone.Infrastructure.Storages
{
    public class StorageOptions
    {
        public string Provider { get; set; }

        public LocalOption Local { get; set; }

        public AzureBlobOption Azure { get; set; }

        public AmazonOptions Amazon { get; set; }

        public bool UsedLocal()
        {
            return Provider == "Local";
        }

        public bool UsedAzure()
        {
            return Provider == "Azure";
        }

        public bool UsedAmazon()
        {
            return Provider == "Amazon";
        }

        public bool UsedFake()
        {
            return Provider == "Fake";
        }
    }
}
