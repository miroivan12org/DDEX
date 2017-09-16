using MusiUploaderWeb.Models.EntityManager;
using MusiUploaderWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusiUploaderWeb.Controllers
{
    public class AccountController : BaseController
    {
        private UserManager userManager;
        public AccountController()
        {
            this.userManager = new UserManager();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginView model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string password = userManager.GetUserPassword(model.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (model.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(model.LoginName, false);
                        SetCulture(model.Language);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserSignUpView user)
        {
            if (ModelState.IsValid)
            {
                if (!userManager.IsLoginNameExist(user.LoginName))
                {
                    userManager.AddUserAccount(user);
                    FormsAuthentication.SetAuthCookie(user.LoginName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View(user);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            string loginName = User.Identity.Name;
            var userProfileView = userManager.GetUserProfile(userManager.GetUserID(loginName));
            return View(userProfileView);
        }


        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(UserSignUpView profile)
        {
            if (ModelState.IsValid)
            {
                userManager.UpdateUserAccount(profile);
                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        private void SetCulture(string cultureCode)
        {
            if (cultureCode == null)
                cultureCode = "hr-HR";
            var cookieCultureLanguage = new HttpCookie("lang")
            {
                Value = cultureCode
            };

            Response.Cookies.Set(cookieCultureLanguage);

            //Sets  Culture for Current thread  
            Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            //Ui Culture for Localized text in the UI  
            Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo(cultureCode);

        }
    }
}