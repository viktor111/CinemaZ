using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlMovieService
    {
        Movie GetMovie(int id);

        Movie GetMovieByName(string name);

        Movie CreateMovie(Movie movie);

        Movie DeleteMovie(Movie movie);

        List<Movie> ListMovies();

        Movie EdditMovie(Movie movie);
    }
}
