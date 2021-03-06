﻿using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.Core;

namespace Mvc.Sample.HealthChecks
{
    public class SampleHealthCheckUnHealthy : App.Metrics.Core.HealthCheck
    {
        public SampleHealthCheckUnHealthy() : base("Sample UnHealthy")
        {
        }

        protected override Task<HealthCheckResult >CheckAsync()
        {
            return Task.FromResult(HealthCheckResult.Unhealthy("OOPS"));
        }
    }
}