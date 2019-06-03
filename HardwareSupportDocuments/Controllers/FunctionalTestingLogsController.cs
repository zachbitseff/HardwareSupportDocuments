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
    public class FunctionalTestingLogsController : Controller
    {
        private ProjectsDB db = new ProjectsDB();

        // GET: FunctionalTestingLogs
        public ActionResult Index()
        {
            var functionalTestingLogs = db.FunctionalTestingLogs.Include(f => f.Project);
            return View(functionalTestingLogs.ToList());
        }

        // GET: FunctionalTestingLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FunctionalTestingLog functionalTestingLog = db.FunctionalTestingLogs.Find(id);
            if (functionalTestingLog == null)
            {
                return HttpNotFound();
            }
            return View(functionalTestingLog);
        }

        // GET: FunctionalTestingLogs/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name");
            return View();
        }

        // POST: FunctionalTestingLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FunctionalTestingLogID,ProjectID,Login,Date,TestName,CurrentStateProblemDescription,ProposedSolution,ChangesMadeDuringTest,Observations,RecommendedChanges,ChangeApproved,Hyperlinks,Results")] FunctionalTestingLog functionalTestingLog)
        {
            if (ModelState.IsValid)
            {
                db.FunctionalTestingLogs.Add(functionalTestingLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", functionalTestingLog.ProjectID);
            return View(functionalTestingLog);
        }

        // GET: FunctionalTestingLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FunctionalTestingLog functionalTestingLog = db.FunctionalTestingLogs.Find(id);
            if (functionalTestingLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", functionalTestingLog.ProjectID);
            return View(functionalTestingLog);
        }

        // POST: FunctionalTestingLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FunctionalTestingLogID,ProjectID,Login,Date,TestName,CurrentStateProblemDescription,ProposedSolution,ChangesMadeDuringTest,Observations,RecommendedChanges,ChangeApproved,Hyperlinks,Results")] FunctionalTestingLog functionalTestingLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(functionalTestingLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Project, "ProjectID", "Name", functionalTestingLog.ProjectID);
            return View(functionalTestingLog);
        }

        // GET: FunctionalTestingLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FunctionalTestingLog functionalTestingLog = db.FunctionalTestingLogs.Find(id);
            if (functionalTestingLog == null)
            {
                return HttpNotFound();
            }
            return View(functionalTestingLog);
        }

        // POST: FunctionalTestingLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FunctionalTestingLog functionalTestingLog = db.FunctionalTestingLogs.Find(id);
            db.FunctionalTestingLogs.Remove(functionalTestingLog);
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
