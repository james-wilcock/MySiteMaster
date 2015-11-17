using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MySite.Models;


namespace MySite.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
      

        public ActionResult Index ()
        {
            return RedirectToAction("Articles", "Article");
            //return View();

        }
        
    }
}
