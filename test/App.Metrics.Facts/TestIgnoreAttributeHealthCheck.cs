using System;
using System.Threading.Tasks;
using App.Metrics.Core;

namespace App.Metrics.Facts
{
    [Obsolete]
    public class IgnoreAttributeHealthCheck : HealthCheck
    {
        public IgnoreAttributeHealthCheck() : base("Referencing Assembly - Sample Healthy")
        {
        }

        protected override Task<HealthCheckResult> CheckAsync()
        {
            return Task.FromResult(HealthCheckResult.Healthy("OK"));
        }
    }
}