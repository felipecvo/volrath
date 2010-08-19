namespace Volrath.Sample.Controllers {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  public class SessionController : Controller {
    public ActionResult New() {
      return View();
    }

    public ActionResult Create(FormCollection form) {
      if (Volrath.User.DoLogin(form["Login"], form["Password"])) {
        return RedirectToRoute(new { controller = "home" });
      }
      return View("New");
    }

    [HttpAuthentication]
    public ActionResult Destroy() {
      Volrath.User.DoLogout();
      return RedirectToRoute(new { controller = "home" });
    }
  }
}
