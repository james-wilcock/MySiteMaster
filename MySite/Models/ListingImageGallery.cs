//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListingImageGallery
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public Nullable<int> ListingID { get; set; }
    
        public virtual Listing Listing { get; set; }
    }
}
