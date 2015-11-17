using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Models;

namespace MySite.DAL
{
    public interface IArticleRepository
    {
        void CreateNewArticle(Article articleToCreate);
        void EditArticle(Article articleToEdit);
        void DeleteArticle(int id);
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticles();
        
    }
}