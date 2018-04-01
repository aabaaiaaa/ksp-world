using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KerbalFlightRegister.Filters
{
    public class ProtectBillAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.RouteData.Values.ContainsValue("bill"))
            {
                var routeData = new System.Web.Routing.RouteValueDictionary(new { controller = "Kerbals", action = "TellMe", kerbalId = "Theres no bill here" });
                filterContext.Result = new RedirectToRouteResult("Kerbals", routeData);
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                return;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}