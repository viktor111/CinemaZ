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
            throw new NotImplementedException();
        }

        public Article DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Article EdditArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Article GetArticle(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> ListArticles()
        {
            throw new NotImplementedException();
        }
    }
}
