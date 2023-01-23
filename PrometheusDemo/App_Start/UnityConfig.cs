using PrometheusDemo.MetricsClasses;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PrometheusDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMonitoring, PrometheusMonitoring>(TypeLifetime.Singleton);
            container.RegisterType<IMetricsOperations, MetricsOperations>(TypeLifetime.Singleton);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}