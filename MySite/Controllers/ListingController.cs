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
using PagedList;

namespace MySite.Controllers
{
    public class ListingController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();
        IListingRepository ar = new EF_ListingRepository();

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
        public ActionResult Create([Bind(Include="Id,DateListed,Status,ListingExpiry,ListingUpdated,ListingAddedBy,ListingUpdatedBy,DateAvailable,ListingType,Price,Deposit,BuildingType,ContractLength,Address,City,Country,Postcode,Description,Rooms,Bedrooms,Size,Bathrooms,Pets,Smoking,DisabledAccess")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: /Listing/Edit/5
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
    }
}
