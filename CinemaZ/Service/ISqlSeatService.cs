using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public interface ISqlSeatService
    {
        Seat GetSeat(int id);

        Seat CreateSeat(Seat seat);

        Seat DeleteSeat(Seat seat);

        List<Seat> ListSeats();

        Seat EdditSeat(Seat seat);
    }
}
