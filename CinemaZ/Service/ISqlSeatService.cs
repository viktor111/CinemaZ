using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlSeatService
    {
        Seat GetSeat(int id);

        List<Seat> ListSeats();

        List<Seat> GenerateSeats(Room room);
    }
}
