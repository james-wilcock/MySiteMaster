namespace MySite.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySite.Models;

    public interface IListingService
    {
        IEnumerable<Listing> GetMyListings();

      
    }
}
