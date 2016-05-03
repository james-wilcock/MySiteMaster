using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySite.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LocationJsonResult() {
           
            return Json(new {town="Toronto", province="Ontario"}, JsonRequestBehavior.AllowGet);       
            }
    }
}