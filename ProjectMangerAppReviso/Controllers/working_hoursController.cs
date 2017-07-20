using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectMangerAppReviso.Models;

namespace ProjectMangerAppReviso.Controllers
{
    public class Working_hoursController : Controller
    {
        private DataModel db = new DataModel();

        // GET: working_hours
        public ActionResult Index()
        {
            var working_hours = db.Working_hours.Include(w => w.Active_projects);
            return View(working_hours.ToList());
        }

        // GET: working_hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Working_hours working_hours = db.Working_hours.Find(id);
            if (working_hours == null)
            {
                return HttpNotFound();
            }
            return View(working_hours);
        }

        // GET: working_hours/Create
        public ActionResult Create()
        {
            ViewBag.pId = new SelectList(db.Active_projects, "id", "pName");
            return View();
        }

        // POST: working_hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pId,startDT,endDT")] Working_hours working_hours)
        {
            if (ModelState.IsValid)
            {
                db.Working_hours.Add(working_hours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pId = new SelectList(db.Active_projects, "id", "pName", working_hours.PId);
            return View(working_hours);
        }

        // GET: working_hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Working_hours working_hours = db.Working_hours.Find(id);
            if (working_hours == null)
            {
                return HttpNotFound();
            }
            ViewBag.pId = new SelectList(db.Active_projects, "id", "pName", working_hours.PId);
            return View(working_hours);
        }

        // POST: working_hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pId,startDT,endDT")] Working_hours working_hours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(working_hours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pId = new SelectList(db.Active_projects, "id", "pName", working_hours.PId);
            return View(working_hours);
        }

        // GET: working_hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Working_hours working_hours = db.Working_hours.Find(id);
            if (working_hours == null)
            {
                return HttpNotFound();
            }
            return View(working_hours);
        }

        // POST: working_hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Working_hours working_hours = db.Working_hours.Find(id);
            db.Working_hours.Remove(working_hours);
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
