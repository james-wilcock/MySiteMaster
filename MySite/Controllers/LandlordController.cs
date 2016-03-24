using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.DAL;
using MySite.Models;

namespace MySite.Controllers
{
    public class LandlordController : Controller
    {

        private DbConnectionContext db = new DbConnectionContext();
        IUserRepository ar = new EF_UserRepository();

        // GET: /Landlord/
        
        public ViewResult Landlord()
        {
            ViewBag.Message = "This can be viewed only by authenticated users only";
            return View();
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include="UserId,Password,FirstName,LastName")] User user)
         {
             if (ModelState.IsValid)
             {
                 user.Active = true;
                 user.Roles = "landlord";
                 ar.CreateNewUser(user);
                 return RedirectToAction("LandlordHome");
             }

             return View("Register");
         }

         [Authorize(Roles = "admin,landlord")]
         public ViewResult LandlordHome()
         {
             ViewBag.Message = "This can be viewed only by authenticated users only";
             return View();
         }

         public ViewResult Register()
         {
             ViewBag.Message = "This can be viewed only by authenticated users only";
             return View();
         }


	}
}