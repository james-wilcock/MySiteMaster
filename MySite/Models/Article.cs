//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Web.Mvc;

namespace MySite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.ImageGalleries = new HashSet<ImageGallery>();
        }
    
        public int ArticleId { get; set; }
       
        public string Title { get; set; }
    [AllowHtml]
        public string ArticleContent { get; set; }
        public string ArticleDate { get; set; }
        public string ArticleImage { get; set; }
        public string ArticleTags { get; set; }
        public string ArticleCategory { get; set; }
        public string ArticleMap { get; set; }
        public string ArticleType { get; set; }
        public string ArticleImageAltText { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
    }
}
