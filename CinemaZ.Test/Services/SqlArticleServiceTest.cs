using System;
using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlArticleServiceTest : DbContextSqlLite
    {
        private readonly SqlArticleService _sqlArticleService;
        
        public SqlArticleServiceTest()
        {
            _sqlArticleService = new SqlArticleService(_dbContext);
        }

        [TestMethod]
        public void ListArticles_ShouldWork()
        {
            //Arrange
            Article article1 = new()
            {
                Text = "random text",
                Title = "rr",
                Views = 100,
            };
            Article article2 = new()
            {
                Text = "ranqweqwedom text",
                Title = "rqweqwer",
                Views = 1012310,
            };
            
            //Act
            _dbContext.Article.Add(article1);
            _dbContext.Article.Add(article2);
            _dbContext.SaveChanges();

            //Assert
            List<Article> articles = _sqlArticleService.ListArticles();
            
            Assert.IsNotNull(articles);
            Assert.AreEqual(2, articles.Count);
        }

        [TestMethod]
        public void GetArticle_ShouldWork()
        {
            //Arrange
            Article article = new()
            {
                Text = "random text",
                Title = "rr",
                Views = 100,
            };

            //Act
            _dbContext.Article.Add(article);
            _dbContext.SaveChanges();

            //Assert
            Article articleDb = _sqlArticleService.GetArticle(article.Id);
            
            Assert.IsNotNull(article);
            Assert.AreEqual(article.Id, articleDb.Id);
            Assert.AreEqual(article.Text, articleDb.Text);
            Assert.AreEqual(article.Title, articleDb.Title);
            Assert.AreEqual(article.Views, articleDb.Views);
        }

        [TestMethod]
        public void EditArticle_ShouldPersist()
        {

            //Arrange
            Article article = new()
            {
                Text = "random text",
                Title = "rr",
                Views = 100,
            };

            _dbContext.Article.Add(article);
            _dbContext.SaveChanges();
            
            Article article2 = new()
            {
                Id = article.Id,
                Text = "ran2312dom 123text",
                Title = "rr23",
                Views = 102320,
            };

            //Act
            _sqlArticleService.EdditArticle(article2);


            //Assert
            Article articleDb = _dbContext.Article.FirstOrDefault(a => a.Id == article.Id);
            
            Assert.AreEqual(article2.Id, articleDb.Id);
            Assert.AreEqual(article2.Text, articleDb.Text);
            Assert.AreEqual(article2.Title, articleDb.Title);
            Assert.AreEqual(article2.Views, articleDb.Views);
        }

        [TestMethod]
        public void DeleteArticle_ShouldWork()
        {
            //Arrange
            Article expected = new()
            {
                Date = DateTime.Now,
                Text = "random text",
                Title = "rr",
                Views = 100,
            };

            //Act
            _dbContext.Article.Add(expected);

            _sqlArticleService.DeleteArticle(expected);

            _dbContext.SaveChanges();

            //Assert
            List<Article> articles = _dbContext.Article.ToList();

            Assert.AreEqual(0,articles.Count);
        }

        [TestMethod]
        public void CreateArticle_ShouldWork()
        {
            //Arrange
            Article expected = new()
            {
                Date = DateTime.Now,
                Text = "random text",
                Title = "rr",
                Views = 100,
            };

            //Act
            _sqlArticleService.CreateArticle(expected);

            //Assert
            Article actual = _dbContext.Article.FirstOrDefault(a => a.Id == expected.Id);
            
            Assert.AreEqual(expected,actual);
        }
    }
}