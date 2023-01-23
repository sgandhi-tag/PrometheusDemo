using Prometheus;
using PrometheusDemo.Infrasturcture;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public class PrometheusMonitoring : IMonitoring
    {
        private static readonly Dictionary<string, Counter> Counters = new Dictionary<string, Counter>();
        //private static readonly Counter ProcessedJobCount = Prometheus.Metrics.CreateCounter("myapp_jobs_processed_total", "Number of processed jobs.");
        public PrometheusMonitoring()
        {
            InitializeCounters();
        }
        public void IncrementCounter(string name, params string[] labelValues)
        {
            if (!Counters.TryGetValue(name, out var counter)) return;
            counter.WithLabels(labelValues).Inc();
        }

        //public static void PrometheusConfiguration()
        //{
        //    var server = new MetricServer(hostname: "localhost", port: 8002);
        //    server.Start();
        //}

        public static void InitializeCounters()
        {
            foreach (var metric in MetricsRegistry.Counters)
            {
                var counter = Metrics.CreateCounter(metric.Name, metric.Description, metric.LabelNames.ToArray());
                Counters.Add(metric.Name, counter);
            }
        }
    }
}