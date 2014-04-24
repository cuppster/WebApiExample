using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cuppster.WebApiExample
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{

			// enable CORS
			config.EnableCors();
		
			// Web API routes
			config.MapHttpAttributeRoutes();

			// Remove the XML formatter
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			// only relying on attributed routes
//			config.Routes.MapHttpRoute(
//				name: "DefaultApi",
//				routeTemplate: "api/{controller}/{id}",
//				defaults: new { id = RouteParameter.Optional }
//			);
		}
	}
}