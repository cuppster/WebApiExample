using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Cuppster.WebApiExample
{
	public static class WebApiConfig
	{
		public static void Register (HttpConfiguration config)
		{

			//
			// WebApi
			//

			// enable CORS
			config.EnableCors ();
		
			// Web API routes
			config.MapHttpAttributeRoutes ();

			// Remove the XML formatter
			config.Formatters.Remove (config.Formatters.XmlFormatter);


		}
	}
}