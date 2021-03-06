﻿using System;
using System.Web.Mvc;
using Mvc3Application.Helpers;

namespace Mvc3Application.Controllers
{
    public class ProtectedController : Controller
    {
        #region protected action

        [SimpleMembership]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region unprotected actions

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string pwd, string ReturnUrl)
        {
            if (pwd == "123")
            {
                Session["myApp-Authentication"] = "123";
                if (ReturnUrl != null)
                    // there's a rediect url, let's redirect the user there
                    return Redirect(ReturnUrl);

                // redirect to Index action
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult SignOut()
        {
            Session["myApp-Authentication"] = null;
            Session.Remove("myApp-Authentication");
            return RedirectToAction("Index");
        }

        #endregion
    }
}
