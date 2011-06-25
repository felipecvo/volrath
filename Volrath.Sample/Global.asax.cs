using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Boycott.Logging;
using Boycott.Provider;

namespace Volrath.Sample
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{

		public override void Init ()
		{
			base.Init ();
			Volrath.HttpSecurityContext.Init (this);
		}

		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");
			
			routes.MapRoute ("login", "login", new { controller = "Session", action = "New" });
			
			// Route name
			// URL with parameters
				// Parameter defaults
			routes.MapRoute ("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
			
		}

		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			
			RegisterRoutes (RouteTable.Routes);
			
			Boycott.Configuration.DatabaseProvider = new MySQLProvider ("localhost", "volrath", "root", "");
			var sync = new Boycott.Mapper.Synchronizator ();
			if (!sync.DatabseExists) {
				Boycott.Configuration.DatabaseProvider.CreateDatabase ();
			}
			
			if (sync.Check ()) {
				sync.Sync ();
			}
		}
	}
}
