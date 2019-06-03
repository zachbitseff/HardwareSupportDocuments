using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HardwareSupportDocuments.Models;

namespace HardwareSupportDocuments.Controllers
{
    public class DeficiencyReportsController : Controller
    {
        private ProjectsDB db = new ProjectsDB();

        // GET: DeficiencyReports
        public ActionResult Index()
        {
            var deficiencyReports = db.DeficiencyReports.Include(d => d.Project);
            return View(deficiencyReports.ToList());
        }

        // GET: DeficiencyReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeficiencyReport deficiencyReport = db.DeficiencyReports.Find(id);
            if (deficiencyReport == null)
            {
                return HttpNotFound();
            }
            return View(deficiencyReport);
        }

        // GET: DeficiencyReports/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name");
            return View();
        }

        // POST: DeficiencyReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeficiencyID,ProjectID,TestConditionsAndResults,MissionImpact,CauseAnalysis,RemedialAction")] DeficiencyReport deficiencyReport)
        {
            if (ModelState.IsValid)
            {
                db.DeficiencyReports.Add(deficiencyReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", deficiencyReport.ProjectID);
            return View(deficiencyReport);
        }

        // GET: DeficiencyReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeficiencyReport deficiencyReport = db.DeficiencyReports.Find(id);
            if (deficiencyReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", deficiencyReport.ProjectID);
            return View(deficiencyReport);
        }

        // POST: DeficiencyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeficiencyID,ProjectID,TestConditionsAndResults,MissionImpact,CauseAnalysis,RemedialAction")] DeficiencyReport deficiencyReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deficiencyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", deficiencyReport.ProjectID);
            return View(deficiencyReport);
        }

        // GET: DeficiencyReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeficiencyReport deficiencyReport = db.DeficiencyReports.Find(id);
            if (deficiencyReport == null)
            {
                return HttpNotFound();
            }
            return View(deficiencyReport);
        }

        // POST: DeficiencyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeficiencyReport deficiencyReport = db.DeficiencyReports.Find(id);
            db.DeficiencyReports.Remove(deficiencyReport);
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
