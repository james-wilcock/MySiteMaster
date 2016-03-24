using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Models;

namespace MySite.DAL
{
    public interface IListingRepository
    {
        void CreateNewListing(Listing listingToCreate);
        void EditListing(Listing listingToEdit);
        void DeleteListing(int id);
        Listing GetListingById(int id);
        IEnumerable<Listing> GetAllListings();
        IEnumerable<Listing> GetMyListings(int userId);

    }
}