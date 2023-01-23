using Prometheus;
using PrometheusDemo.Infrasturcture;
using PrometheusDemo.MetricsClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PrometheusDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AspNetMetricServer.RegisterRoutes(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            GlobalFilters.Filters.Add(new LogAttribute());
            //MetricsClasses.PrometheusMonitoring.PrometheusConfiguration();
            //MetricsClasses.PrometheusMonitoring.InitializeCounters();

        }

        protected void Application_BeginRequest()
        {
            if (Context.Request.Path.Equals("/metrics", StringComparison.OrdinalIgnoreCase))
            {
                var authorizationHeader = Context.Request.Headers["Authorization"];

                if (!String.IsNullOrEmpty(authorizationHeader))
                {
                    var credentials = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authorizationHeader.Substring(6))).Split(':');
                    var user = new { Name = credentials[0], Pass = credentials[1] };
                    if (user.Name == "admin" && user.Pass == "test") return;
                }

                Response.Clear();
                Response.SuppressFormsAuthenticationRedirect = true;
                Response.StatusCode = (Int32)HttpStatusCode.Unauthorized;
                Response.AddHeader("WWW-Authenticate", "Basic");
            }
        }
    }
}
