using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MySite.DAL;
using MySite.Models;
using MySite.Services;
using PagedList;
using MySite.Infrastructure;
namespace MySite.Controllers
{
    public class ListingController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();
        IListingRepository ar = new EF_ListingRepository();


        //private IListingService service;

        //public ListingController(IListingService service)
        //{
        //    this.service = service;
        //}

        // GET: /Listing/
        public ActionResult Index()
        {
            return View(db.Listings.ToList());
        }

       

        // GET: /Listing/
        // GET: /Article/Articles
        public ViewResult MyListings(int? page)
        {

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            string username =
                           FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;

            int userId;
            using (MySiteEntities entities = new MySiteEntities())
            {
                User user = entities.Users.SingleOrDefault(u => u.UserId == username);

                userId = user.Id;
            }
            return View(ar.GetMyListings(userId).ToPagedList(pageNumber, pageSize));
        }

        // GET: /Listing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: /Listing/Create
         [Authorize(Roles = "admin,landlord,realtor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Listing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin,landlord,realtor")]
        public ActionResult Create([Bind(Include="Id, DateAvailable, Price,Deposit,BuildingType,ContractLength,Address,City,Country,Postcode,Description,Rooms,Bedrooms,Size,Bathrooms,Pets,Smoking,DisabledAccess")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                listing.DateListed = DateTime.Now;
                listing.Status = MySite.Infrastructure.SiteConstants.PropertyStatus.ForRent;
                listing.ListingExpiry = DateTime.Now.AddMonths(1);
                listing.ListingUpdated = listing.DateListed;
                listing.ListingAddedBy = Profile.UserName;
                listing.ListingUpdatedBy = listing.ListingAddedBy;
                listing.ListingType = MySite.Infrastructure.SiteConstants.ListingType.ForRent;

                db.Listings.Add(listing);
                db.SaveChanges();
                string mystring = ViewBag.Files;

var query = from val in mystring.Split(',')
            select int.Parse(val);
foreach (int num in query)
{
   var original = db.ListingsImageGalleries.Find(num);

if (original != null)
{
    original.ListingID = listing.Id;
    db.SaveChanges();
}    
}
             

                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: /Listing/Edit/5
        [Authorize(Roles = "admin,landlord,realtor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: /Listing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin,landlord,realtor")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DateListed,Status,ListingExpiry,ListingUpdated,ListingAddedBy,ListingUpdatedBy,DateAvailable,ListingType,Price,Deposit,BuildingType,ContractLength,Address,City,Country,Postcode,Description,Rooms,Bedrooms,Size,Bathrooms,Pets,Smoking,DisabledAccess")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        // GET: /Listing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: /Listing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

          [HttpPost]
           public ActionResult UploadImageMethod()
            {
                if (Request.Files.Count != 0)
                {
                    string[] keys = Request.Files.AllKeys;
                    string inserted = "";
                    string[] insertedValues = new string[Request.Files.Count];
                   
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        int fileSize = file.ContentLength;
                        string fileName = keys[i];
                        var target = "/Content/Images/" + fileName;
                        var path = Server.MapPath(target);
                        file.SaveAs(path);
                        ListingImageGallery imageGallery = new ListingImageGallery();
                   
                        imageGallery.Name = fileName;
                        imageGallery.ImagePath = fileName;
                        db.ListingsImageGalleries.Add(imageGallery);
                        db.SaveChanges();

                        insertedValues[i] = imageGallery.ID.ToString();

                    }
                    inserted = string.Join(",", insertedValues);
                    ViewBag.Files=inserted;
                    return Content("Success");
                }
                return Content("failed");
            }

    }
}
