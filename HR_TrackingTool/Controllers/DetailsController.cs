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
   
    public class DetailsController : Controller
    {
        private lenoraEntities db = new lenoraEntities();
        public ActionResult Index(string searchBy, string search)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }
           
           else if (searchBy == "Skills")
            {
                return View(db.Details.Where(x => x.Primary_Skills.Contains(search)|| x.Secondary_Skills.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Details.Where(x => x.First_Name.Contains(search)||x.Last_Name.Contains(search) || search == null).ToList());
            }
        }
      
       

        // GET: Details/Details/5
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
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Candidate_id,First_Name,Last_Name,Email,Ph_Number,Visa_Status,Primary_Skills,Secondary_Skills,Candidate_degree,Majaor_degree,Biling_Status,Resume,Resume1")] Detail detail)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detail);
        }

        // GET: Details/Edit/5
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
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Candidate_id,First_Name,Last_Name,Email,Ph_Number,Visa_Status,Primary_Skills,Secondary_Skills,Candidate_degree,Majaor_degree,Biling_Status,Resume")] Detail detail)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "UserLogin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Delete/5
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
            Detail detail = db.Details.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(String search_string)
        {
            
            return View(/*db.Details.Where()*/);
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
