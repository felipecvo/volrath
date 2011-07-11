namespace Volrath {
    using System.Web.Mvc;

    public class SessionController : Controller {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult New() {
            return View(new User());
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection) {
            var user = Volrath.User.Build(collection);
            if (user.DoLogin()) {
                return RedirectToRoute(new { controller = "Home" });
            }
            ViewData["Error"] = "Login e/ou senha inválido(s).";
            return View("New", user);
        }

        [HttpAuthentication]
        public ActionResult Destroy() {
            Volrath.User.DoLogout();
            return RedirectToAction("New", new User());
        }
    }
}
