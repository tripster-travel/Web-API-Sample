using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Travel.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Web API configuration and services
					
			// remove xml so we only get json
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			// get camel case 
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			//config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
