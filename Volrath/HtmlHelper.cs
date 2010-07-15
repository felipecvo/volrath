namespace Volrath {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Web;

  public static class HtmlHelper {
    public static string ContinueInputHidden() {
      if (!string.IsNullOrEmpty(HttpContext.Current.Request.Params["continue"])) {
        return string.Format("<input name=\"continue\" type=\"hidden\" value=\"{0}\" />", HttpContext.Current.Request.Params["continue"]);
      }
      return null;
    }
  }
}
