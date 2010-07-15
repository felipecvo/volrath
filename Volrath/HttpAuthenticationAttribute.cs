namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web.Mvc;
  using System.Web;

  public class HttpAuthenticationAttribute : AuthorizeAttribute {
    protected override bool AuthorizeCore(HttpContextBase httpContext) {
      return HttpSecurityContext.CurrentUser != null;
    }
  }
}
