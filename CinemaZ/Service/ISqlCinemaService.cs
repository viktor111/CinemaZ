using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlCinemaService
    {
        Cinema GetCinema(int id);

        Cinema CreateCinema(Cinema cinema);

        Cinema DeleteCinema(Cinema cinema);

        List<Cinema> ListCinemas();

        List<Room> ListRooms(Cinema cinema);

        Cinema EdditCinema(Cinema cinema);
    }
}
