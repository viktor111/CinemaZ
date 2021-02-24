using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlSeatService
    {
        Seat GetSeat(int id);

        Seat CreateSeat(Seat seat);

        Seat DeleteSeat(Seat seat);

        List<Seat> ListSeats();

        Seat EdditSeat(Seat seat);

        List<Seat> GenerateSeats(Room room);
    }
}
