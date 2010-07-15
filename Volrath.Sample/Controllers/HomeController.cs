using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Volrath.Sample.Controllers {
  public class HomeController : Controller {
    //
    // GET: /Home/

    public ActionResult Index() {
      return View();
    }

    public string Show() {
      var user = (from u in Volrath.User.db
                  select u).First();

      return "show";
    }

    public string List() {
      var user = (from u in Volrath.User.db
                  select u).ToList();

      return "list";
    }
  }
}
