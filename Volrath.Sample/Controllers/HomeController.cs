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
            var permissions = (from p in Permission.db
                select p);
            var rolePermissions = (from p in RolePermission.db
                select p);
            var role = (from p in Role.db
                select p);
            var userRole = (from p in UserRole.db
                select p);
            
            var permissions2 = (from p in Permission.db
                join rp in RolePermission.db on p.Id equals rp.PermissionId
                /*join r in Role.db on rp.RoleId equals r.Id
                join ur in UserRole.db on r.Id equals ur.RoleId
                where ur.UserId == 1*/
                select p).ToList();
            
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
