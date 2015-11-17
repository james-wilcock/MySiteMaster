using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySite.Models;

namespace MySite.DAL
{
    public class EF_ArticleRepository : IArticleRepository
    {
        private DbConnectionContext db = new DbConnectionContext();

        public void CreateNewArticle(Article articleToCreate)
        {
            db.Articles.Add(articleToCreate);
            db.SaveChanges();
        }

        public void EditArticle(Article articleToEdit)
        {
            db.Entry(articleToEdit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
        }

        public Article GetArticleById(int id)
        {
            return db.Articles.Find(id);
        }

        public IEnumerable<Article> GetAllArticles()
        {
          return  db.Articles.ToList();
        }

      
     

    }
}