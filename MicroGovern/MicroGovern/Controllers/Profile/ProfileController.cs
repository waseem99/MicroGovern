using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MicroGovern.Models.Profile;
using MicroGovern.Models;

namespace MicroGovern.Controllers.Profile
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            return RedirectToAction("myProfile"); 
        }

        public ActionResult myProfile()
        {
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
            return View(myDetails);
        }
    }
}