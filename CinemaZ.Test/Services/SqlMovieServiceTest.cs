using System;
using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlMovieServiceTest : DbContextSqlLite
    {
        private readonly SqlMovieService _sqlMovieService;
        
        public SqlMovieServiceTest()
        {
            _sqlMovieService = new SqlMovieService(_dbContext);
        }

        [TestMethod]
        public void ListMovies_ShouldWork()
        {
            //Arrange
            Movie movie1 = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };
            Movie movie2 = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };
            
            //Act
            _dbContext.Movie.Add(movie1);
            _dbContext.Movie.Add(movie2);
            _dbContext.SaveChanges();

            //Assert
            List<Movie> movies = _sqlMovieService.ListMovies();
            
            Assert.IsNotNull(movies);
            Assert.AreEqual(2, movies.Count);
        }

        [TestMethod]
        public void GetMovie_ShouldWork()
        {
            //Arrange
            Movie movie = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };

            //Act
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();

            //Assert
            Movie movieDb = _sqlMovieService.GetMovie(movie.Id);
            
            Assert.IsNotNull(movieDb);
            Assert.AreEqual(movie.Id,movieDb.Id);
            Assert.AreEqual(movie.Premiere,movieDb.Premiere);
            Assert.AreEqual(movie.Picture,movieDb.Picture);
            Assert.AreEqual(movie.Category,movieDb.Category);
            Assert.AreEqual(movie.Price,movieDb.Price);
            Assert.AreEqual(movie.PremiereId,movieDb.PremiereId);
            Assert.AreEqual(movie.MovieRoom,movieDb.MovieRoom);

        }

        [TestMethod]
        public void DeleteMovie_ShouldWork()
        {
            //Arrange
            Movie movie = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };

            //Act
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();

            _sqlMovieService.DeleteMovie(movie);

            //Assert
            Movie movieDb = _dbContext.Movie.FirstOrDefault(m => m.Id == movie.Id);

            Assert.IsNull(movieDb);
        }

        [TestMethod]
        public void EditMovie_ShouldPersist()
        {
            //Arrange
            Movie movie = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };           

            //Act
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();

            Movie newMovie = new()
            {
                Id = movie.Id,
                Category = CategoryType.Action,
                Name = "we123",
                Picture = "we312",
                Premiere = new Premiere(),
                Price = 902M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                ReleaseDate = DateTime.Now,
            };

            _sqlMovieService.EdditMovie(newMovie);

            //Assert
            Movie movieDb = _dbContext.Movie.FirstOrDefault(m => m.Id == movie.Id);
            
            Assert.IsNotNull(movieDb);
            Assert.AreEqual(newMovie.Id,movieDb.Id);
            Assert.AreEqual(newMovie.Premiere,movieDb.Premiere);
            Assert.AreEqual(newMovie.Picture,movieDb.Picture);
            Assert.AreEqual(newMovie.Category,movieDb.Category);
            Assert.AreEqual(newMovie.Price,movieDb.Price);
        }

        [TestMethod]
        public void CreateMovie_ShouldPersist()
        {
            //Arrange
            Movie movie = new()
            {
                Category = CategoryType.Action,
                Name = "we",
                Picture = "we",
                Premiere = new Premiere(),
                Price = 90M,
                MovieRating = MovieRatingType.A,
                MovieRoom = new List<MovieRoom>(),
                PremiereId = 1,
                ReleaseDate = DateTime.Now,
            };
            //Act
            _sqlMovieService.CreateMovie(movie);

            //Assert
            Movie movieDb = _dbContext.Movie.FirstOrDefault(m => m.Id == movie.Id);
            
            Assert.IsNotNull(movieDb);
            Assert.AreEqual(movie.Id,movieDb.Id);
            Assert.AreEqual(movie.Premiere,movieDb.Premiere);
            Assert.AreEqual(movie.Picture,movieDb.Picture);
            Assert.AreEqual(movie.Category,movieDb.Category);
            Assert.AreEqual(movie.Price,movieDb.Price);
            Assert.AreEqual(movie.PremiereId,movieDb.PremiereId);
            Assert.AreEqual(movie.MovieRoom,movieDb.MovieRoom);
        }
    }
}