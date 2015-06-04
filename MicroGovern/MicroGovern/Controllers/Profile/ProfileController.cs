using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MicroGovern.Models.Profile;
using MicroGovern.Models;
using System.Data.Entity;
using MicroGovern.Models.Services_mng;

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
            /*Service  dd  = db.Services.Find(1043);
            myDetails.myServices.Add(new UserService() {
                providedService = dd
            });

            dd = db.Services.Find(1045);
            myDetails.myServices.Add(new UserService()
            {
                providedService = dd
            });

            dd = db.Services.Find(1046);
            myDetails.myServices.Add(new UserService()
            {
                providedService = dd
            });
            
            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();*/
            return View(myDetails);
        }

        public ActionResult myProfile_edit()
        {
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);

            ViewBag.servicesList = db.Services.ToList().Where(x => x.isleaf == false);

            return View(myDetails);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult myProfile_addService(int serviceId)
        {
            Service newService = db.Services.Find(serviceId);
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
            UserService newUserService = new UserService(){ providedService = newService };
            myDetails.myServices.Add(newUserService);
            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();

            return Json(newUserService, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult myProfile_deleteService(int serviceId)
        {
            Service newService = db.Services.Find(serviceId);
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);

            List<UserService> myServices = myDetails.myServices.ToList<UserService>();
            UserService temp = myServices.Find(item => item.ID == serviceId);

            myDetails.myServices.Remove(temp);

            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}