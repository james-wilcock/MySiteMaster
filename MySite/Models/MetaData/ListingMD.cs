using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySite.Models
{
    [MetadataType(typeof(ListingMd))]
    public partial class Listing
    {
        // Add logic to the generated class in here.
          public string FrontImagePath
      {
           get
          {
              
                  if (ListingImageGalleries.Count > 0)
                 {     
                    return ListingImageGalleries.Where(a => Id == Convert.ToInt32(HeadImage)).FirstOrDefault().ImagePath.ToString();
              }
          else
                {
                    return  "";
                }
          
             
         }
      }

    }


    internal class ListingMd
    {


        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Price { get; set; }

     
   

        public int Id { get; set; }
        public int HeadImage { get; set; }
        
        public DateTime DateListed  { get; set; }

        public virtual ICollection<ListingImageGallery> ListingImageGalleries { get; set; }
  

    }

}