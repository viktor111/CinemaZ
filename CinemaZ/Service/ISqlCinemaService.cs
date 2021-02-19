using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public interface ISqlCinemaService
    {
        Cinema GetCinema(int id);

        Cinema CreateCinema(Cinema cinema);

        Cinema DeleteCinema(Cinema cinema);

        List<Cinema> ListCinemas();

        Cinema EdditCinema(Cinema cinema);
    }
}
