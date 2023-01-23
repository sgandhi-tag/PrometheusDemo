using PrometheusDemo.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public static class MetricState
    {
        public const string Failed = "failed";
        public const string Succeeded = "Succeeded";
    }
    
    public static class AvailableMetrics
    {
        private const string MetricNamePrefix = "tcol_";
        
        public static readonly string Match1Score = FormatCounterName(nameof(Match1Score));
        public static readonly string Match2Score = FormatCounterName(nameof(Match2Score));
        public static readonly string Match3Score = FormatCounterName(nameof(Match3Score));
        
        private static string FormatCounterName(string name)
        {
            return MetricNamePrefix + name.ToLowerSnakeCase() + "_total";
        }
    }
    
    public static class MetricsRegistry
    {
        public static readonly ReadOnlyCollection<Metric> Counters = new List<Metric>
                                                                     {
                                                                         Metric.Create(AvailableMetrics.Match1Score, "Score for Match 1", "teamNumber"),
                                                                         Metric.Create(AvailableMetrics.Match2Score, "Score for Match 2", "teamNumber"),
                                                                         Metric.Create(AvailableMetrics.Match3Score, "Score for Match 3", "teamNumber"),
                                                                     }.AsReadOnly();
    }
}