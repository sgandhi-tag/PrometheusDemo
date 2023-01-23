using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public class Metric
    {
        private Metric(string name,
                       string description,
                       IEnumerable<string> labelNames)
        {
            Name = name;
            Description = description;
            LabelNames.AddRange(labelNames);
        }
        
        public string Name { get; }
        public string Description { get; }
        public List<string> LabelNames { get; } = new List<string>();
        
        public static Metric Create(string name,
                                    string description,
                                    params string[] labelNames)
        {
            return new Metric(name, description, labelNames);
        }
    }
}