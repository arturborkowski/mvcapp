using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplikacjaMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASP .NET Aplication by Artur Borkowski.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Artur Borkowski";

            return View();
        }
    }
}