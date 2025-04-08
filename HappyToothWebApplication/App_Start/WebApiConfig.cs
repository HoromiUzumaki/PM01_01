using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Unity.AspNet.WebApi;
using Unity.Lifetime;
using Unity;

namespace HappyToothWebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка DI
            var container = new UnityContainer();
            container.RegisterType<HappyToothEntities>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Маршруты API
            config.MapHttpAttributeRoutes();
            // Маршруты Web API
          

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

        }
    }
}
