using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MicroGovern.Models;
using System.Data.Entity;
using MicroGovern.Models.Services_mng;
using System.IO;

namespace MicroGovern.Controllers.Profile
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("myProfile_edit");
        }

        public ActionResult myProfile(String userID)
        {
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
            return View(myDetails);
        }

        [Authorize]
        public ActionResult myProfile_edit()
        {
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
            ViewBag.servicesList = db.Services.ToList().Where(x => x.isleaf == false);

            return View(myDetails);
        }

        [Authorize]
        [System.Web.Mvc.HttpGet]
        public JsonResult myProfile_addService(int serviceId)
        {
            Service newService = db.Services.Find(serviceId);
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
            UserService newUserService = new UserService() { providedService = newService };
            myDetails.myServices.Add(newUserService);
            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();

            return Json(newUserService, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [System.Web.Mvc.HttpGet]
        public JsonResult myProfile_updateNameAndDesc(String newName, String newDesc)
        {
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);

            myDetails.FullName = newName;
            myDetails.whoAmI = newDesc;

            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [System.Web.Mvc.HttpGet]
        public JsonResult myProfile_updateRate(float newRate)
        {
            var userID = User.Identity.GetUserId();
            UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);

            myDetails.stats.avgRatePerHr = newRate;

            db.Entry(myDetails).State = EntityState.Modified;
            db.SaveChanges();

            return Json("", JsonRequestBehavior.AllowGet);
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public ActionResult ProfilePicUpload(HttpPostedFileBase photo)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                var userID = User.Identity.GetUserId();
                UserDetails myDetails = db.usersdb.Single(x => x.ApplicationUserId == userID);
                var fileName = myDetails.ID + "_profile_" + Path.GetFileName(photo.FileName);
                var previousDP = myDetails.profilePicURL;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/img/profile"), fileName);
                photo.SaveAs(path);


                myDetails.profilePicURL = "/Content/img/profile/" + fileName;

                db.Entry(myDetails).State = EntityState.Modified;
                db.SaveChanges();

                string fullPath = Request.MapPath("~" + previousDP);
                if (System.IO.File.Exists(fullPath) && previousDP != myDetails.profilePicURL)
                {
                    System.IO.File.Delete(fullPath);
                    //Session["DeleteSuccess"] = "Yes";
                }

            }
            return RedirectToAction("myProfile_edit");
        }
    }
}
