using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MicroGovern.Models.Profile;

namespace MicroGovern.Controllers.Profile
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return RedirectToAction("myProfile"); 
        }

        public ActionResult myProfile()
        {
            return View();
        }
    }
}