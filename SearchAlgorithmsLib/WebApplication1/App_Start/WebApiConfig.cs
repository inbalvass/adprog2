using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetSolution",
                routeTemplate: "api/{controller}/{name}/{algo}",
                defaults: new { Controller = "SinglePlayer" }
            );

            config.Routes.MapHttpRoute(
                name: "GetSinglePlayers",
                routeTemplate: "api/{controller}/{name}/{rows}/{cols}",
                defaults: new { Controller = "SinglePlayer" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "PostDbInfo",
            //    routeTemplate: "api/{controller}/{dbInfo}",
            //    defaults: new { Controller = "DbInfoes" }
            //);

            config.Routes.MapHttpRoute(
                 name: "GetDbInfos",
                 routeTemplate: "api/{controller}",
                defaults: new { Controller = "DbInfoes" }
            );

            /*  config.Routes.MapHttpRoute(
                  name: "GetDbInfo",
                  routeTemplate: "api/{controller}/{name}/{password}",
                  defaults: new { Controller = "DbInfoes" }
              );*/



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
