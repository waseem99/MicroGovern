using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MicroGovern.Models;
using MicroGovern.Models.Request_mng;

namespace MicroGovern.Controllers.Services_Management.Request_mng
{
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request aRequest = db.Requests.Find(id);
            if (aRequest == null)
            {
                return HttpNotFound();
            }
            return View(aRequest);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,RequestIniated,Details,MinRate,MaxRate,WorkDueDate,WorkableTimeRange,PicURL,BidsVisibility")] Request aRequest)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(aRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aRequest);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request aRequest = db.Requests.Find(id);
            if (aRequest == null)
            {
                return HttpNotFound();
            }
            return View(aRequest);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,RequestIniated,Details,MinRate,MaxRate,WorkDueDate,WorkableTimeRange,PicURL,BidsVisibility")] Request aRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aRequest);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request aRequest = db.Requests.Find(id);
            if (aRequest == null)
            {
                return HttpNotFound();
            }
            return View(aRequest);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request aRequest = db.Requests.Find(id);
            db.Requests.Remove(aRequest);
            db.SaveChanges();
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
