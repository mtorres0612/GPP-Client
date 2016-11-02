using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPPClientModel;
using GPPClientBL;
using System.Web.Security;
namespace GPPClient.Controllers
{
    public class UserController : Controller
    {
        UserBL oUserBL = UserBL.GetInstance(); 

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                List<User> userItem = oUserBL.GetAll(user.UserName, user.Password);

                if (userItem.Count > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "User");
        }
    }
}
