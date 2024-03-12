using CrudMVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CrudMVCCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Account/Login
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Account/Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Authentication(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Launch");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password!");
                }
            }

            return View(model);
        }

        /// <summary>
        /// Account/Logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// User verification occurs here, such as checking that the username and password are correct
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        private bool Authentication(string userName, string password)
        {
            //User authentication is done here, such as querying the database or calling an external authentication service
            return (userName == "admin" && password == "password");
        }
    }
}