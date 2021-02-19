using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlMovieService : ISqlMovieService
    {
        private ApplicationDbContext _dbContext;

        public SqlMovieService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _dbContext.Movie.Add(movie);

            _dbContext.SaveChanges();

            return new Movie();
        }

        public Movie DeleteMovie(Movie movie)
        {
            _dbContext.Movie.Remove(movie);

            _dbContext.SaveChanges();

            return new Movie();
        }

        public Movie EdditMovie(Movie movie)
        {
            Movie movieToEdit = _dbContext.Movie.Where(m => m.Id == movie.Id).FirstOrDefault();

            movieToEdit.Category = movie.Category;
            movieToEdit.MovieRating = movie.MovieRating;
            movieToEdit.Name = movie.Name;
            movieToEdit.Picture = movie.Picture;
            movieToEdit.Premiere = movie.Premiere;
            movieToEdit.PremiereId = movie.PremiereId;
            movieToEdit.Price = movie.Price;

            _dbContext.SaveChanges();

            return new Movie();
        }

        public Movie GetMovie(int id)
        {
            return _dbContext.Movie.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Movie> ListMovies()
        {
            return _dbContext.Movie.OrderBy(m => m.ReleaseDate).ToList();
        }
    }
}
