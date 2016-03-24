using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;
using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    [MetadataType(typeof(ListingMd))]
    public partial class Listing
    {
        // Add logic to the generated class in here.


    }


    internal class ListingMd
    {


        [DisplayFormat(DataFormatString = "{0:C}")]
        public string Price { get; set; }


        // public virtual ICollection<ImageGallery> ImageGalleries { get; set; }

    }

}