using KerbalFlightRegister.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerbalFlightRegister.Controllers
{
    public class KerbalsController : Controller
    {
        // GET: Kerbals/
        // GET: Kerbals/search/123
        [ProtectBill]
        public ActionResult Search(string kerbalId)
        {
            ViewBag.kerbalId = kerbalId ?? "none";

            return View();
        }

        //GET: kerbals/tellme/something
        public ActionResult TellMe(string kerbalId)
        {
            var encodedKerbalId = Server.HtmlEncode(kerbalId);
            return Content(encodedKerbalId);
        }

        //GET: kerbals/redirect/anything
        public ActionResult Redirect(string kerbalId)
        {
            return RedirectToAction("tellme", "kerbals", new { kerbalId = "redirected" });
        }

        //GET: kerbals/getfile/anything[or nothing]
        public ActionResult GetFile(string kerbalId)
        {
            // Forget the kerbalId
            return File(Server.MapPath("~/content/site.css"), "text/css");
        }

        public ActionResult ReturnJson()
        {
            return Json(new { Name = "Bill", Location = "Mun", FlightTime = 12354543 }, JsonRequestBehavior.AllowGet);
        }
    }
}