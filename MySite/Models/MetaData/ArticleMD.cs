using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;
using System.ComponentModel.DataAnnotations;

namespace MySite.Models
{
    [MetadataType(typeof (ArticleMd))]
    public partial class Article
    {
        // Add logic to the generated class in here.


    }


    internal class ArticleMd
    {


        [AllowHtml]
        public string ArticleContent { get; set; }


        // public virtual ICollection<ImageGallery> ImageGalleries { get; set; }

    }

}