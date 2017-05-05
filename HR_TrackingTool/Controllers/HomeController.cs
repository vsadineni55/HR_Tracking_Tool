using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.AccessControl;

namespace HR_TrackingTool.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "HR-Tracking Tool";
            Session.Abandon();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Lenora Systems.";
            Session.Abandon();

            return View();
        }
    }
}