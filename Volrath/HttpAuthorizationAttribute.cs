namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web.Mvc;
  using System.Web;
  using System.Web.Routing;

  public class HttpAuthorizationAttribute : AuthorizeAttribute {
    public string Permission { get; set; }

    public override void OnAuthorization(AuthorizationContext filterContext) {
      if (!AuthorizeCore(filterContext.HttpContext)) {
        filterContext.HttpContext.Response.StatusCode = 403;
      }
    }

    protected override bool AuthorizeCore(HttpContextBase httpContext) {
      if (string.IsNullOrEmpty(Permission)) {
        var wrapper = new HttpContextWrapper(HttpContext.Current);
        var routeData = RouteTable.Routes.GetRouteData(wrapper);
        Permission = string.Format("{0}/{1}", routeData.Values["controller"].ToString().ToLower(), routeData.Values["action"].ToString().ToLower());
      }

      if (HttpSecurityContext.CurrentUser != null) {
        if (!HttpSecurityContext.CurrentUser.HasPermission(Permission)) {
          httpContext.Response.StatusCode = 403;
          httpContext.Response.ClearContent();
          httpContext.Response.Write("<html><head><title>403 Forbidden</title></head><body><h1>Access is forbidden!</h1><p>You have not permission to see the requested page.</p></body></html>");
          httpContext.Response.End();
        }
      }
      return true;
    }
  }
}
