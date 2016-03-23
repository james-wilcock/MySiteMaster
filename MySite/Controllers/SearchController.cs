﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.DAL;
using MySite.Models;
using PagedList;
namespace MySite.Controllers
{
    public class SearchController : Controller
    {
    
          private DbConnectionContext db = new DbConnectionContext();
        IArticleRepository ar = new EF_ArticleRepository();

        // GET: /Article/Articles
        public ViewResult Search(int? page)
        {

            int pageSize = 9;
            int pageNumber = (page ?? 1);
           
            return View(ar.GetAllArticles().ToPagedList(pageNumber, pageSize));
        }
        

          public ActionResult Detail(int? id)
        {
            
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int v2 = id ?? default(int);
            Article article = ar.GetArticleById(v2);

            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

    //    public ActionResult Search(String SearchType, String SearchString)
    //    {
    //        if (SearchType == "Rent")
    //        {
    //            return View();
//return View(db.Employees.Where(x => x.Gender == search || search ==null).ToList());
    //        }
   //         else
    //        {
   //             return View();
//return View(db.Employees.Where(x => x.Name.StartsWith(search)).ToList());
     //       }

     //   }

    }
}