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
    
    public class Job_DescriptionController : Controller
    {
        private lenoraEntities db = new lenoraEntities();

        // GET: Job_Description
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Login", "UserLogin");
            }
            return View(db.Job_Description.ToList());
        }

        // GET: Job_Description/Details/5
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
            Job_Description job_Description = db.Job_Description.Find(id);
            if (job_Description == null)
            {
                return HttpNotFound();
            }
            return View(job_Description);
        }

        // GET: Job_Description/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Login", "UserLogin");
            }
            return View();
        }

        // POST: Job_Description/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Job_Id,Job_Title,Skills,Roles_Resposibilities,Email,contact_number")] Job_Description job_Description)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Job_Description.Add(job_Description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job_Description);
        }

        // GET: Job_Description/Edit/5
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
            Job_Description job_Description = db.Job_Description.Find(id);
            if (job_Description == null)
            {
                return HttpNotFound();
            }
            return View(job_Description);
        }

        // POST: Job_Description/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Job_Id,Job_Title,Skills,Roles_Resposibilities,Email,contact_number")] Job_Description job_Description)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(job_Description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job_Description);
        }

        // GET: Job_Description/Delete/5
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
            Job_Description job_Description = db.Job_Description.Find(id);
            if (job_Description == null)
            {
                return HttpNotFound();
            }
            return View(job_Description);
        }

        // POST: Job_Description/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserID"] == null)
            {

                return RedirectToAction("Login", "UserLogin");
            }
            Job_Description job_Description = db.Job_Description.Find(id);
            db.Job_Description.Remove(job_Description);
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
