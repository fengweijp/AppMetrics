// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Text;
using App.Metrics.Data;

namespace App.Metrics.Formatting.Humanize
{
    public sealed class HumanizeTimerMetricFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                return string.Empty;
            }

            if (!(arg is TimerValueSource))
            {
                return arg.ToString();
            }

            var timer = (TimerValueSource)arg;

            var sb = new StringBuilder();

            sb.AppendLine();

            sb.HummanizeTimer(timer);

            return sb.ToString();
        }
    }
}