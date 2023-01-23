using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public interface IMonitoring
    {
        void IncrementCounter(string name, params string[] labelValues);
    }
}