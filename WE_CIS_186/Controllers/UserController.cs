using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WE_CIS_186.Models;
using WE_CIS_186.Encrypt;

namespace WE_CIS_186.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LoginPage()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginPage(UserValidate user)
        {
            // Db
            using (wenevaescapeEntities db = new wenevaescapeEntities())
            {
                //var EncryptedUsersPassword = EncryptS.Hash(user.password);
                if (ModelState.IsValid)
                {

                    var xUser = db.Users.Where(x => x.username == user.username && x.password == user.password).FirstOrDefault();
                    if (xUser != null)
                    {
                        Session["ID"] = xUser.id;
                        Session["Username"] = xUser.username;
                        Session["Role"] = xUser.role;
                        switch (xUser.role.ToString())
                        {
                            //admin
                            case "1":
                                return RedirectToAction("CustomerList", "Home");
                            //other
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.LoginError = "Wrong username or password.";
                        return View("LoginPage", user);
                    }
                }
                else
                {
                    ViewBag.LoginError = "Wrong username or password.";
                    return View("LoginPage", user);
                }

            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginPage", "User");
        }
    }
}