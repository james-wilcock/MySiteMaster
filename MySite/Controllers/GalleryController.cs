﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.Models;

namespace MySite.Controllers
{
    public class GalleryController : Controller
    {

            private readonly DbConnectionContext db = new DbConnectionContext();
            public ActionResult Index()
            {
                var imagesModel = new ImageGallery();
                var imageFiles = Directory.GetFiles(Server.MapPath("~/Upload_Files/"));
                foreach (var item in imageFiles)
                {
                    imagesModel.ImageList.Add(Path.GetFileName(item));
                }
                return View(imagesModel);
            }
            
            [HttpGet]
            public ActionResult UploadImage()
            {
                return View();
            }
            [HttpPost]
            public ActionResult UploadImageMethod()
            {
                if (Request.Files.Count != 0)
                {
                    string[] keys = Request.Files.AllKeys;
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        int fileSize = file.ContentLength;
                        string fileName = keys[i];
                        var target = "~/Upload_Files/" + fileName;
                        var path = Server.MapPath(target);
                        file.SaveAs(path);
                        ImageGallery imageGallery = new ImageGallery();
                        imageGallery.ID = Guid.NewGuid();
                        imageGallery.Name = fileName;
                        imageGallery.ImagePath = "~/Upload_Files/" + fileName;
                        db.ImageGallery.Add(imageGallery);
                        db.SaveChanges();
                    }
                    return Content("Success");
                }
                return Content("failed");
            }
      

      

          
    
        }
    }  
