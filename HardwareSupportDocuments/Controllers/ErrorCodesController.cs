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
    public class ErrorCodesController : Controller
    {
        private ProjectsDB db = new ProjectsDB();

        // GET: ErrorCodes
        public ActionResult Index()
        {
            return View(db.ErrorCodes.ToList());
        }

        // GET: ErrorCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorCodes errorCodes = db.ErrorCodes.Find(id);
            if (errorCodes == null)
            {
                return HttpNotFound();
            }
            return View(errorCodes);
        }

        // GET: ErrorCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ErrorCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ErrorID,ErrorCode,ErrorCodeDescription,Subsystem,Component,FailureMode,FaultLogID")] ErrorCodes errorCodes)
        {
            if (ModelState.IsValid)
            {
                db.ErrorCodes.Add(errorCodes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(errorCodes);
        }

        // GET: ErrorCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorCodes errorCodes = db.ErrorCodes.Find(id);
            if (errorCodes == null)
            {
                return HttpNotFound();
            }
            return View(errorCodes);
        }

        // POST: ErrorCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ErrorID,ErrorCode,ErrorCodeDescription,Subsystem,Component,FailureMode,FaultLogID")] ErrorCodes errorCodes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(errorCodes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(errorCodes);
        }

        // GET: ErrorCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorCodes errorCodes = db.ErrorCodes.Find(id);
            if (errorCodes == null)
            {
                return HttpNotFound();
            }
            return View(errorCodes);
        }

        // POST: ErrorCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ErrorCodes errorCodes = db.ErrorCodes.Find(id);
            db.ErrorCodes.Remove(errorCodes);
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
