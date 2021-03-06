﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WE_CIS_186.Models;
using WE_CIS_186.Encrypt;

namespace WE_CIS_186.Controllers
{
    [HandleError]
    public class UserController : Controller
    {

        // GET: User
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LoginPage()
        {
            UserValidate model = new UserValidate();
            return View(model);
        }

        //Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserValidate user)
        {
            if (ModelState.IsValid)
            {
                // Db
                using (wenevaescapeEntities db = new wenevaescapeEntities())
                {
                    var EncryptedUsersPassword = EncryptS.Hash(user.loginPassword);
                    var xUser = db.Users.Where(x => x.username == user.loginUsername && x.password == EncryptedUsersPassword).FirstOrDefault();
                    if (xUser != null)
                    {
                        Session["ID"] = xUser.id;
                        Session["Username"] = xUser.username;
                        Session["Role"] = xUser.role;
                        switch (xUser.role.ToString())
                        {
                            //admin
                            case "1":
                                return RedirectToAction("Index", "Home");
                            //other
                            default:
                                return RedirectToAction("Index", "Home");
                        }
                    }
                    ViewBag.LoginError = "Wrong username or password.";
                    return View("LoginPage", new UserValidate());
                }
            }
            return RedirectToAction("LoginPage", new UserValidate());
        }
        //Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserValidate user, User xUser)
        {
            if (ModelState.IsValid)
            {
                using (wenevaescapeEntities db = new wenevaescapeEntities())
                {
                    if (db.Users.Any(x => x.username == user.registerUsername))
                    {
                        ViewBag.RegisterError = "This username has already used.";
                        return View("LoginPage", new UserValidate());
                    }
                    xUser.username = user.registerUsername.ToString();
                    xUser.password = EncryptS.Hash(user.registerPassword).ToString();
                    xUser.role = (int)1;
                    db.Users.Add(xUser);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    ViewBag.SuccessMessage = "Your account successfully registered.";
                    return View("LoginPage", new UserValidate());
                }
            }
            return View("LoginPage", new UserValidate());
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginPage", "User");
        }
    }
}