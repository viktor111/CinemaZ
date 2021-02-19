using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public interface ISqlMovieService
    {
        Movie GetMovie(int id);

        Movie CreateMovie(Movie movie);

        Movie DeleteMovie(Movie movie);

        List<Movie> ListMovies();

        Movie EdditMovie();
    }
}
