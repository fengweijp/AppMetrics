﻿using System;
using System.Linq;
using App.Metrics.Data;
using App.Metrics.Formatters.Json.Facts.Helpers;
using App.Metrics.Formatters.Json.Facts.TestFixtures;
using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace App.Metrics.Formatters.Json.Facts
{
    public class HistogramSerializationTests : IClassFixture<MetricProviderTestFixture>
    {
        private readonly HistogramValueSource _histogram;
        private readonly ITestOutputHelper _output;
        private readonly MetricDataSerializer _serializer;

        public HistogramSerializationTests(ITestOutputHelper output, MetricProviderTestFixture fixture)
        {
            _output = output;
            _serializer = new MetricDataSerializer();
            _histogram = fixture.Histograms.First();
        }

        [Fact]
        public void can_deserialize()
        {
            var jsonHistogram = MetricType.Histogram.SampleJson();

            var result = _serializer.Deserialize<HistogramValueSource>(jsonHistogram.ToString());

            result.Name.Should().BeEquivalentTo(_histogram.Name);
            result.Unit.Should().Be(_histogram.Unit);
            result.Value.Count.Should().Be(_histogram.Value.Count);
            result.Value.LastValue.Should().Be(_histogram.Value.LastValue);
            result.Value.LastUserValue.Should().Be(_histogram.Value.LastUserValue);
            result.Value.Max.Should().Be(_histogram.Value.Max);
            result.Value.MaxUserValue.Should().Be(_histogram.Value.MaxUserValue);
            result.Value.Mean.Should().Be(_histogram.Value.Mean);
            result.Value.Min.Should().Be(_histogram.Value.Min);
            result.Value.MinUserValue.Should().Be(_histogram.Value.MinUserValue);
            result.Value.StdDev.Should().Be(_histogram.Value.StdDev);
            result.Value.Median.Should().Be(_histogram.Value.Median);
            result.Value.Percentile75.Should().Be(_histogram.Value.Percentile75);
            result.Value.Percentile95.Should().Be(_histogram.Value.Percentile95);
            result.Value.Percentile98.Should().Be(_histogram.Value.Percentile98);
            result.Value.Percentile99.Should().Be(_histogram.Value.Percentile99);
            result.Value.Percentile999.Should().Be(_histogram.Value.Percentile999);
            result.Value.SampleSize.Should().Be(_histogram.Value.SampleSize);
            result.Tags.Should().ContainKeys(_histogram.Tags.Select(t => t.Key));
            result.Tags.Should().ContainValues(_histogram.Tags.Select(t => t.Value));
        }

        [Fact]
        public void produces_expected_json()
        {
            var expected = MetricType.Histogram.SampleJson();

            var result = _serializer.Serialize(_histogram).ParseAsJson();

            result.Should().Be(expected);
        }

        [Fact]
        public void produces_valid_Json()
        {
            var json = _serializer.Serialize(_histogram);
            _output.WriteLine("Json Histogram: {0}", json);

            Action action = () => JToken.Parse(json);
            action.ShouldNotThrow<Exception>();
        }
    }
}