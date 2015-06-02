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
    }
}