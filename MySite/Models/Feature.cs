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
    
    public partial class Feature
    {
        public int Id { get; set; }
        public int ListingId { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public string FeatureAddedBy { get; set; }
        public Nullable<System.DateTime> FeatureAdded { get; set; }
    
        public virtual Listing Listing { get; set; }
    }
}
