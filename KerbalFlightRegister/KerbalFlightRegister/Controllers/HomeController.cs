using KerbalFlightRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerbalFlightRegister.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel()
            {
                Administrator = "Gene Kerbin",
                Since = new DateTime(2017, 10, 1)
            };

            var routeModel = new RouteModel()
            {
                Controller = RouteData.Values["controller"].ToString(),
                Action = RouteData.Values["action"].ToString(),
                Id = RouteData.Values["id"]?.ToString() ?? "none"
            };

            ViewBag.RouteUsed = string.Format("{0}/{1}/{2}", routeModel.Controller, routeModel.Action, routeModel.Id);

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}