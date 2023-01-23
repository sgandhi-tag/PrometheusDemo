using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrometheusDemo.MetricsClasses
{
    public class MetricsOperations : IMetricsOperations
    {

        private readonly IMonitoring _Imonitoring;

        public MetricsOperations(IMonitoring Imonitoring) =>
            _Imonitoring = Imonitoring;

        //PrometheusMonitoring monitoring;

        public void Team1ScoreMetrics(int match)
        {
            //monitoring = new PrometheusMonitoring();
            if (match == 1)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match1Score, "team1");
            }
            if (match == 2)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match2Score, "team1");
            }
            if (match == 3)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match3Score, "team1");
            }
        }

        public void Team2ScoreMetrics(int match)
        {
            //monitoring = new PrometheusMonitoring();

            if (match == 1)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match1Score, "team2");
            }
            if (match == 2)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match2Score, "team2");
            }
            if (match == 3)
            {
                _Imonitoring.IncrementCounter(AvailableMetrics.Match3Score, "team2");
            }
        }
    }
}