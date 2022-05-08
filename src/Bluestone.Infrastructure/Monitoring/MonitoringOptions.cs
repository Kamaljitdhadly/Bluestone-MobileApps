using Bluestone.Infrastructure.Monitoring.AppMetrics;
using Bluestone.Infrastructure.Monitoring.AzureApplicationInsights;
using Bluestone.Infrastructure.Monitoring.MiniProfiler;

namespace Bluestone.Infrastructure.Monitoring
{
    public class MonitoringOptions
    {
        public MiniProfilerOptions MiniProfiler { get; set; }

        public AzureApplicationInsightsOptions AzureApplicationInsights { get; set; }

        public AppMetricsOptions AppMetrics { get; set; }
    }
}
