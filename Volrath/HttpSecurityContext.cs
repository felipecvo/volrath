namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web;
  using System.Web.Security;

  public static class HttpSecurityContext {
    public static User CurrentUser {
      get {
        if (HttpContext.Current == null) return null;

        if (HttpContext.Current.Items["Volrath.HttpSecurityContext.CurrentUser"] != null)
          return HttpContext.Current.Items["Volrath.HttpSecurityContext.CurrentUser"] as User;

        var cookie = HttpContext.Current.Request.Cookies["SID"];
        if (cookie == null) return null;

        var ticket = FormsAuthentication.Decrypt(cookie.Value);
        if (ticket == null) return null;

        int userId = 0;
        if (int.TryParse(ticket.UserData, out userId)) {
          var user = (from u in User.db where u.Id == userId select u).Single();
          HttpContext.Current.Items["Volrath.HttpSecurityContext.CurrentUser"] = user;
          return user;
        }

        return null;
      }
    }

    public static void Init(HttpApplication application) {
      application.EndRequest += new EventHandler(application_EndRequest);
    }

    static void application_EndRequest(object sender, EventArgs e) {
      if (HttpContext.Current.Response.StatusCode == 401) {
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.StatusCode = 302;
        HttpContext.Current.Response.RedirectLocation = string.Format("{0}?continue={1}", Settings.LoginUrl, HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri));
        HttpContext.Current.Response.End();
      }
    }
  }  
}
