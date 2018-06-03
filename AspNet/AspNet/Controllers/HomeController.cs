using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNet.Models;

namespace AspNet.Controllers
{
    //[Authorize(Roles ="Administrator")]
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            Model1 m = new Model1();
            List<String> imena = new List<string>();
            foreach (Dojava d in m.Dojavas) imena.Add(d.Mjesto);
            //ViewData["Dojave"] = imena.ToArray();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "E-routing.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}