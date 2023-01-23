using Prometheus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PrometheusDemo
{
    public class PrometheusConfig
    {
        private static readonly Counter match1_teamScore = Metrics.CreateCounter("Match_Score_1", "Score of team1 hockey for 1st match",
        new CounterConfiguration
        {
            // Here you specify only the names of the labels.
            LabelNames = new[] { "teamNumber" }
        });

        private static readonly Counter match2_teamScore = Metrics.CreateCounter("Match_Score_2", "Score of team1 hockey for 2nd match",
        new CounterConfiguration
        {
            // Here you specify only the names of the labels.
            LabelNames = new[] { "teamNumber" }
        });

        private static readonly Counter match3_teamScore = Metrics.CreateCounter("Match_Score_3", "Score of team1 hockey for 3rd match",
        new CounterConfiguration
        {
            // Here you specify only the names of the labels.
            LabelNames = new[] { "teamNumber" }
        });

        public static void PrometheusConfiguration()
        {
            // NB! On .NET Core and .NET 5+ you should use KestrelMetricServer instead, to benefit from latest runtime improvements.
            // MetricServer is the .NET Standard implementation designed for maximum compatibility across frameworks.
            var server = new MetricServer(hostname: "localhost", port: 44316, url: "metrics/admin");
            server.Start();
        }

        public static void Team1ScoreMetrics(int match)
        {
            if (match == 1)
            {
                match1_teamScore.WithLabels("team1").Inc();
            }
            if (match == 2)
            {
                match2_teamScore.WithLabels("team1").Inc();
            }
            if (match == 3)
            {
                match3_teamScore.WithLabels("team1").Inc();
            }
        }

        public static void Team2ScoreMetrics(int match)
        {
            if (match == 1)
            {
                match1_teamScore.WithLabels("team2").Inc();
            }
            if (match == 2)
            {
                match2_teamScore.WithLabels("team2").Inc();
            }
            if (match == 3)
            {
                match3_teamScore.WithLabels("team2").Inc();
            }
        }
    }

}