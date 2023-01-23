using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public interface IMetricsOperations
    {
        void Team1ScoreMetrics(int match);
        void Team2ScoreMetrics(int match);
    }
}