using NSwag.AspNet.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Travel.App
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			RouteTable.Routes.MapOwinPath("swagger", app =>
			{
				app.UseSwaggerUi3(typeof(WebApiApplication).Assembly, settings =>
				{
					settings.MiddlewareBasePath = "/swagger";
					settings.GeneratorSettings.DefaultUrlTemplate = "api/{controller}/{id}";  //this is the default one
					//settings.GeneratorSettings.DefaultUrlTemplate = "api/{controller}/{action}/{id}";
				});
			});

			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
    }
}
