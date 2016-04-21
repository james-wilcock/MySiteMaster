using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.DAL;
using MySite.Models;
using PagedList;
namespace MySite.Controllers
{
    public class SearchController : Controller
    {
    
          private DbConnectionContext db = new DbConnectionContext();
        IListingRepository lr = new EF_ListingRepository();

        // GET: /Article/Articles
        public ViewResult Search(int? page)
        {

            int pageSize = 9;
            int pageNumber = (page ?? 1);
           
            return View(lr.SearchListings().ToPagedList(pageNumber, pageSize));
        }
        



          public ActionResult Detail(int? id)
        {
            
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int v2 = id ?? default(int);
            Listing listing = lr.GetListingById(v2);

            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

    //    public ActionResult Search(String SearchType, String SearchString)
    //    {
    //        if (SearchType == "Rent")
    //        {
    //            return View();
//return View(db.Employees.Where(x => x.Gender == search || search ==null).ToList());
    //        }
   //         else
    //        {
   //             return View();
//return View(db.Employees.Where(x => x.Name.StartsWith(search)).ToList());
     //       }

     //   }

    }
}