using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MicroGovern.Models;
using MicroGovern.Models.Services_mng;

namespace MicroGovern.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services
        public ActionResult Index()
        {
            //List<Service> allServices = db.Services.ToList();
            //allServices = allServices.Where( x => x.isleaf == false);
            return View(db.Services.ToList().Where(x => x.isleaf == false));
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult getSubServices(int serviceId)
        {
             IEnumerable<Service> subServiceslist = db.Services.ToList().Where(x => x.ID == serviceId);

            return Json(subServiceslist, JsonRequestBehavior.AllowGet);
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id, int? parentServiceID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.parentServiceID = -1;
            if(parentServiceID >= 0)
                ViewBag.parentServiceID = parentServiceID;

            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,isleaf,Name,Description,icon,DateAdded")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.isleaf = false;
                //service.subServices = new List<Service>();
                //Service new1 = new Service() { DateAdded = DateTime.Now, Description = "test2 ", icon = "asd", isleaf = false, Name = "MicroElectric" };
                //service.add(new1);
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }



        // GET: Services/Edit/5
        public ActionResult Edit(int? id, int? parentServiceID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.parentServiceID = -1;
            if(parentServiceID >= 0)
                ViewBag.parentServiceID = parentServiceID;
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,isleaf,Name,Description,icon,DateAdded")] Service service, int parentServiceID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                if(parentServiceID == -1)
                    return RedirectToAction("Index");
                return RedirectToAction("Details/" + parentServiceID);
            }
            return View(service);
        }


        // GET: Services/Create
        public ActionResult CreateSubService(int? parentServiceID)
        {
            ViewBag.parentServiceID = parentServiceID;
            return View();
        }
        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubService([Bind(Include = "ID,isleaf,Name,Description,icon,DateAdded")] Service service, int? parentServiceID)
        {
            if (ModelState.IsValid)
            {
                service.isleaf = true;
                Service mainService = db.Services.Find(parentServiceID);
                mainService.add(service);
                db.Entry(mainService).State = EntityState.Modified;
                db.SaveChanges();
                if (parentServiceID == -1)
                    return RedirectToAction("Index");
                return RedirectToAction("Details/" + parentServiceID);
            }
            ViewBag.parentServiceID = parentServiceID;
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id, int? parentServiceID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.parentServiceID = parentServiceID;
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? parentServiceID)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            if(parentServiceID >= 0)
                return RedirectToAction("Details/" + parentServiceID);
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
