using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySite.DAL;
using MySite.Models;

namespace MySite.Controllers
{
    public class ArticleController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();
        IArticleRepository ar = new EF_ArticleRepository();

        // GET: /Article/
        public ActionResult Articles()
        {
          
            return View(ar.GetAllArticles());
        }

        // GET: /Article/Details/5
        public ActionResult Details(int? id)
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

        // GET: /Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ArticleId,Title,ArticleContent,ArticleDate,ArticleImage")] Article article)
        {
            if (ModelState.IsValid)
            {
              ar.CreateNewArticle(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: /Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int v2 = id ?? default(int);
            Article article = db.Articles.Find(v2);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: /Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ArticleId,Title,ArticleContent,ArticleDate,ArticleImage")] Article article)
        {
            if (ModelState.IsValid)
            {
               ar.EditArticle(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: /Article/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ar.DeleteArticle(id);
            return RedirectToAction("Index");
        }

      
    }
}
