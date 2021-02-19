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
            throw new NotImplementedException();
        }

        public Movie DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie EdditMovie()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> ListMovies()
        {
            throw new NotImplementedException();
        }
    }
}
