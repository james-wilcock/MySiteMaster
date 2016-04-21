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
    
    public partial class Listing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Listing()
        {
            this.UserListings = new HashSet<UserListing>();
            this.ListingImageGalleries = new HashSet<ListingImageGallery>();
            this.Features = new HashSet<Feature>();
            this.ListingDetails = new HashSet<ListingDetail>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateListed { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ListingExpiry { get; set; }
        public Nullable<System.DateTime> ListingUpdated { get; set; }
        public string ListingAddedBy { get; set; }
        public string ListingUpdatedBy { get; set; }
        public Nullable<System.DateTime> DateAvailable { get; set; }
        public string ListingType { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Deposit { get; set; }
        public string BuildingType { get; set; }
        public string ContractLength { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Rooms { get; set; }
        public Nullable<decimal> Bedrooms { get; set; }
        public Nullable<decimal> Size { get; set; }
        public Nullable<decimal> Bathrooms { get; set; }
        public Nullable<bool> Pets { get; set; }
        public Nullable<bool> Smoking { get; set; }
        public Nullable<bool> DisabledAccess { get; set; }
        public string Furnished { get; set; }
        public string PriceType { get; set; }
        public Nullable<int> Storeys { get; set; }
        public string BasementType { get; set; }
        public string Community { get; set; }
        public string LaundryType { get; set; }
        public string HeatingType { get; set; }
        public Nullable<int> ParkingSpaces { get; set; }
        public string Utilities { get; set; }
        public Nullable<decimal> ServiceCharge { get; set; }
        public string CoolingType { get; set; }
        public string ParkingType { get; set; }
        public string FuelType { get; set; }
        public Nullable<decimal> WalkScore { get; set; }
        public string SizeUnits { get; set; }
        public Nullable<int> HeadImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserListing> UserListings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListingImageGallery> ListingImageGalleries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feature> Features { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListingDetail> ListingDetails { get; set; }
    }
}
