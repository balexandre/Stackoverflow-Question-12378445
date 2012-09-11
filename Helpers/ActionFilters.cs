using System;
using System.Web.Mvc;

namespace Mvc3Application.Helpers
{
    public class SimpleMembershipAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //redirect if not authenticated
            if (filterContext.HttpContext.Session["myApp-Authentication"] == null ||
                filterContext.HttpContext.Session["myApp-Authentication"] != "123")
            {
                //use the current url for the redirect
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;

                //send them off to the login page
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = "/Protected/SignIn" + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }
}