using CinemaZ.Models;
using System.Collections.Generic;

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
