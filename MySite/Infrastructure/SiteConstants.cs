using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Infrastructure
{
    public class SiteConstants
    {
         public static class PropertyStatus
        {
            public const string ForRent = "For Rent";
            public const string ForSale = "For Sale";
            public const string Let = "Let";
            public const string Sold = "Sold";
            public const string Unnavailable = "No longer available";
        }

         public static class ListingType
        {
            public const string ForRent = "For Rent";
            public const string ForSale = "For Sale";
           
        }
    }
}