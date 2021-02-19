using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlArticleService : ISqlArticleService
    {
        private ApplicationDbContext _dbContext;

        public SqlArticleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Article CreateArticle(Article article)
        {
            _dbContext.Article.Add(article);

            _dbContext.SaveChanges();

            return new Article();
        }

        public Article DeleteArticle(Article article)
        {
            _dbContext.Remove(article);

            _dbContext.SaveChanges();

            return new Article();
        }

        public Article EdditArticle(Article articleModel)
        {
            Article articleToEdit = _dbContext.Article.Where(a => a.Id == articleModel.Id).FirstOrDefault();

            articleToEdit.Date = DateTime.Now;
            articleToEdit.Text = articleModel.Text;
            articleToEdit.Title = articleModel.Title;
            articleToEdit.Views = articleModel.Views;

            _dbContext.SaveChanges();

            return articleToEdit;
        }

        public Article GetArticle(int id)
        {
            return _dbContext.Article.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Article> ListArticles()
        {
            return _dbContext.Article.OrderBy(a => a.Date).ToList();
        }
    }
}
