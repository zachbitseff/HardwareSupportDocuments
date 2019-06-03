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
    public class FaultRecoveryLogsController : Controller
    {
        private ProjectsDB db = new ProjectsDB();

        // GET: FaultRecoveryLogs
        public ActionResult Index()
        {
            var faultRecoveryLogs = db.FaultRecoveryLogs.Include(f => f.Project);
            return View(faultRecoveryLogs.ToList());
        }

        // GET: FaultRecoveryLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaultRecoveryLog faultRecoveryLog = db.FaultRecoveryLogs.Find(id);
            if (faultRecoveryLog == null)
            {
                return HttpNotFound();
            }
            return View(faultRecoveryLog);
        }

        // GET: FaultRecoveryLogs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name");
            return View();
        }

        // POST: FaultRecoveryLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaultLogID,ProjectID,Date,Login,ErrorID,EventDescription,PartsReplaced,PartNumber,RecoverySteps,Hyperlinks,Results")] FaultRecoveryLog faultRecoveryLog)
        {
            if (ModelState.IsValid)
            {
                db.FaultRecoveryLogs.Add(faultRecoveryLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", faultRecoveryLog.ProjectID);
            return View(faultRecoveryLog);
        }

        // GET: FaultRecoveryLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaultRecoveryLog faultRecoveryLog = db.FaultRecoveryLogs.Find(id);
            if (faultRecoveryLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", faultRecoveryLog.ProjectID);
            return View(faultRecoveryLog);
        }

        // POST: FaultRecoveryLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaultLogID,ProjectID,Date,Login,ErrorID,EventDescription,PartsReplaced,PartNumber,RecoverySteps,Hyperlinks,Results")] FaultRecoveryLog faultRecoveryLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faultRecoveryLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", faultRecoveryLog.ProjectID);
            return View(faultRecoveryLog);
        }

        // GET: FaultRecoveryLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaultRecoveryLog faultRecoveryLog = db.FaultRecoveryLogs.Find(id);
            if (faultRecoveryLog == null)
            {
                return HttpNotFound();
            }
            return View(faultRecoveryLog);
        }

        // POST: FaultRecoveryLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FaultRecoveryLog faultRecoveryLog = db.FaultRecoveryLogs.Find(id);
            db.FaultRecoveryLogs.Remove(faultRecoveryLog);
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
