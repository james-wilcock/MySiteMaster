using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySite.Models
{

        public class DbConnectionContext : DbContext
        {
            public DbConnectionContext()
                : base("name=dbContext")
            {
               // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbConnectionContext>());
                this.Configuration.ProxyCreationEnabled = false; 
            }
         
            public DbSet<ImageGallery> ImageGallery { get; set; }

            public System.Data.Entity.DbSet<MySite.Models.Article> Articles { get; set; }
            public System.Data.Entity.DbSet<MySite.Models.User> Users { get; set; }

            public System.Data.Entity.DbSet<MySite.Models.Listing> Listings { get; set; }
            public System.Data.Entity.DbSet<MySite.Models.UserListing> UserListings { get; set; }

          public System.Data.Entity.DbSet<MySite.Models.ListingImageGallery> ListingsImageGalleries { get; set; }
          
        }
    
}