// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


// Originally Written by Iulian Margarintescu https://github.com/etishor/Metrics.NET
// Ported/Refactored to .NET Standard Library by Allan Hardy


using App.Metrics.Data;
using App.Metrics.Data.Interfaces;

namespace App.Metrics.Core.Interfaces
{
    /// <summary>
    ///     Provides access to a timer metric implementation e.g. <see cref="TimerMetric" />, allows custom timers to be
    ///     implemented
    /// </summary>
    /// <seealso cref="ITimer" />
    /// <seealso cref="IMetricValueProvider{T}" />
    public interface ITimerMetric : ITimer, IMetricValueProvider<TimerValue>
    {
    }
}