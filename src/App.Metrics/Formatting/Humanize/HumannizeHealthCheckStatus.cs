// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using App.Metrics.Internal;

// ReSharper disable CheckNamespace
namespace App.Metrics.Core
// ReSharper restore CheckNamespace
{
    public static class HumannizeHealthCheckStatus
    {
        public static string Hummanize(this HealthCheckStatus status)
        {
            return Constants.Health.HealthStatusDisplay[status];
        }
    }
}