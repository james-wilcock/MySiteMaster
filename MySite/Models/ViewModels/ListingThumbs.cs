using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySite.Models.ViewModels
{
    public class ListingThumbs
    {

          public int Id { get; set; }
          public Nullable<decimal> Price { get; set; }
          public string PriceType { get; set; }
          public string City { get; set; }
          public string Address { get; set; }
          public Nullable<int> HeadImage { get; set; }
         public string   HeadImagePath { get; set; }
    }
}