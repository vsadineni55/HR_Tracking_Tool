using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HR_TrackingTool.Models;

namespace HR_TrackingTool.Controllers
{
    
    public class Applied_JobsController : Controller
    {
        private lenoraEntities db = new lenoraEntities();

        // GET: Applied_Jobs
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View(db.Applied_Jobs.ToList());
            }
            else
            {
                return RedirectToAction("Login","UserLogin");
            }
           
        }

        // GET: Applied_Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Applied_Jobs applied_Jobs = db.Applied_Jobs.Find(id);
                if (applied_Jobs == null)
                {
                    return HttpNotFound();
                }
                return View(applied_Jobs);
            
        }

        // GET: Applied_Jobs/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Job_id,Job_Title,Vendor,Client,VendorPOC,Location,Submitted_Rate,Candidates_Submitted,Status,Additional_Info,Date_Recevied")] Applied_Jobs applied_Jobs)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Applied_Jobs.Add(applied_Jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applied_Jobs);
        }

        // GET: Applied_Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applied_Jobs applied_Jobs = db.Applied_Jobs.Find(id);
            if (applied_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(applied_Jobs);
        }

        // POST: Applied_Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Job_id,Job_Title,Vendor,Client,VendorPOC,Location,Submitted_Rate,Candidates_Submitted,Status,Additional_Info,Date_Recevied")] Applied_Jobs applied_Jobs)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(applied_Jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applied_Jobs);
        }

        // GET: Applied_Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applied_Jobs applied_Jobs = db.Applied_Jobs.Find(id);
            if (applied_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(applied_Jobs);
        }

        // POST: Applied_Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserID"] == null)

            {
                return RedirectToAction("Login", "UserLogin");
            }
            Applied_Jobs applied_Jobs = db.Applied_Jobs.Find(id);
            db.Applied_Jobs.Remove(applied_Jobs);
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
