using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareSupportDocuments.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to the Hardware Support Docs Site!";
;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Info:";

            return View();
        }
    }
}