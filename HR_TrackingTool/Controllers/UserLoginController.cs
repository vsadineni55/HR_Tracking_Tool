using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

using HR_TrackingTool.Models;
using System.Web.Security;

namespace HR_TrackingTool.Controllers
{
    public class UserLoginController : Controller
    {
        private lenoraEntities db = new lenoraEntities();
        // GET: Logins
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblLogin objUser)
        {
            
            if (ModelState.IsValid)
            {
                using (lenoraEntities db = new lenoraEntities())
                {
                    var obj = db.tblLogins.Where(model => model.User_name.Equals(objUser.User_name) && model.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {

                        Session["UserID"] = obj.User_name.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","UserLogin");
            }
        }
        public ActionResult StateArea()
        {
            using (lenoraEntities dc = new lenoraEntities())
            {
                var v = dc.Details.ToList();
                return View(v);
            }
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}