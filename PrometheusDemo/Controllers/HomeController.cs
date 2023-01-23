using PrometheusDemo.Infrasturcture;
using PrometheusDemo.MetricsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrometheusDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMetricsOperations _metricsOperations;
        public HomeController() // MVC can call that
        {
        }

        public HomeController(IMetricsOperations metricsOperations) =>
            _metricsOperations = metricsOperations;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hockey()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScoreIncrement(int teamScore, int team, int match)
        { 
            teamScore = teamScore + 1;
            if(team == 1)
            {
                _metricsOperations.Team1ScoreMetrics(match);
            }
            if (team == 2)
            {
                _metricsOperations.Team2ScoreMetrics(match);
            }

            return Json(teamScore);
        }
    }
}