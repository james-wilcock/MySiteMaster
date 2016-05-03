using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySite.Models;
using MySite.Models.ViewModels;

namespace MySite.DAL
{
    public class EF_ListingRepository : IListingRepository
    {
        private DbConnectionContext db = new DbConnectionContext();

        public void CreateNewListing(Listing listingToCreate)
        {
            db.Listings.Add(listingToCreate);
            db.SaveChanges();
        }

        public void EditListing(Listing listingToEdit)
        {
            db.Entry(listingToEdit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteListing(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
        }

        public Listing GetListingById(int id)
        {
            return db.Listings.Find(id);
        }

        public IEnumerable<Listing> GetAllListings()
        {
            IEnumerable<Listing> lists = from g in db.Listings
                join u in db.ListingsImageGalleries on g.HeadImage equals u.ListingID
                select g;
                                          return lists;
        }

          public IEnumerable<Listing> SearchListings()
        {
         IEnumerable<Listing> lists = from g in db.Listings
                                        orderby g.DateListed
              select g;
                                          return lists;
        }

           

        public IEnumerable<Listing> GetMyListings(int userId)
        {

            IEnumerable<Listing> lists = from g in db.Listings
                join u in db.UserListings on g.Id equals u.Listing_Id
                        where u.User_Id.Equals(userId)
                        orderby u.Listing_Id
                select g;

            return lists;
        }

           public IEnumerable<Listing> GetMyListingsById(int userId, int id)
        {

            IEnumerable<Listing> lists = from g in db.Listings
                join u in db.UserListings on g.Id equals u.Listing_Id
                        where u.User_Id.Equals(userId) && g.Id.Equals(id) 
                        orderby u.Listing_Id
                select g;

            return lists;
        }



         
    }
}