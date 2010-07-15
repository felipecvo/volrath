namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web.Security;

  internal class Settings {
    static Settings() {
      SaltBase64 = "12345678";
      LoginUrl = "/login";
    }
    public static string SaltBase64 { set; get; }
    public static string LoginUrl { get; set; }
    public static string CookieDomain {
      get {
        return FormsAuthentication.CookieDomain;
      }
    }
  }
}
