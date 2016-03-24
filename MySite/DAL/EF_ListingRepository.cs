﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySite.Models;

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
            return db.Listings.ToList();
        }

        public IEnumerable<Listing> GetMyListings(int userId)
        {
            
var query = from g in db.Listings
            join u in db.UserListings on g.User_Id equals u.userID
            select new { g, u, });
        }




    }
}