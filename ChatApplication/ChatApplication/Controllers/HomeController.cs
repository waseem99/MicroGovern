using ChatApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            //var userl = UserManager.FindById(User.Identity.GetUserId());
            /*
            string userId = User.Identity.GetUserId();
            string user = "User : "+ userId;
            Session["UserName"] = user;
            Session["UserId"] = userId;

            if (OnlineUser.userObj.Where(item => item.sessionId == HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value.ToString()).Count() > 0)
                OnlineUser.userObj.Remove(OnlineUser.userObj.Where(item => item.sessionId == HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value.ToString()).FirstOrDefault());
            OnlineUser.AddOnlineUser("", "User : " + userId, userId);
            hdnUserId.Value = Session["UserId"].ToString();
            hdnUserName.Value = Session["UserName"].ToString();*/
            return View();
        }
    }
}