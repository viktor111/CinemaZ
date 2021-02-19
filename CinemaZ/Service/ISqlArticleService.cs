using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public interface ISqlArticleService
    {
        Article GetArticle(int id);

        Article CreateArticle(Article article);

        Article DeleteArticle(Article article);

        List<Article> ListArticles();

        Article EdditArticle(Article article);
    }
}
