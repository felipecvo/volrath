using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ActiveRecord.net.Logging;
using ActiveRecord.net.Provider;

namespace Volrath.Sample {
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication {

    public override void Init() {
      base.Init();
      Volrath.HttpSecurityContext.Init(this);
    }

    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute("login", "login", new { controller = "session", action = "new" });

      routes.MapRoute(
          "Default", // Route name
          "{controller}/{action}/{id}", // URL with parameters
          new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
      );

    }

    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();

      RegisterRoutes(RouteTable.Routes);

      DatabaseProvider.Logger = new FileLogger(@"c:\temp\logs\database.log");
    }
  }
}