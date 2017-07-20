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
    public class Active_projectsController : Controller
    {
        private DataModel db = new DataModel();

        // GET: active_projects
        public ActionResult Index()
        {
            return View(db.Active_projects.ToList());
        }

        // GET: active_projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_projects active_projects = db.Active_projects.Find(id);
            if (active_projects == null)
            {
                return HttpNotFound();
            }
            return View(active_projects);
        }

        // GET: active_projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: active_projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PName,AuthorName,CustomerName,StartDate,EndDate")] Active_projects active_projects)
        {
            if (ModelState.IsValid)
            {
                db.Active_projects.Add(active_projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(active_projects);
        }

        // GET: active_projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_projects active_projects = db.Active_projects.Find(id);
            if (active_projects == null)
            {
                return HttpNotFound();
            }
            return View(active_projects);
        }

        // POST: active_projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pName,authorName,customerName,startDate,endDate")] Active_projects active_projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(active_projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(active_projects);
        }

        // GET: active_projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Active_projects active_projects = db.Active_projects.Find(id);
            if (active_projects == null)
            {
                return HttpNotFound();
            }
            return View(active_projects);
        }

        // POST: active_projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Active_projects active_projects = db.Active_projects.Find(id);
            db.Active_projects.Remove(active_projects);
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
