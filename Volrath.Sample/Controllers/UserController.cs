namespace Volrath.Sample.Controllers {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using System.Web.Mvc;

  public class UserController : Controller {
    public ActionResult New() {
      return View(new User());
    }

    public ActionResult Create(FormCollection form) {
      var user = Volrath.User.Build(form);
      if (user.Save()) {
        return RedirectToAction("Index");
      } else {
        return View("New", user);
      }
    }

    public ActionResult Index() {
      var users = (from u in Volrath.User.db
                   select u).ToList();
      return View(users);
    }

    public ActionResult Delete(int id) {
      Volrath.User.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
