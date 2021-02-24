using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.Service
{
    public interface ISqlRoomService
    {
        Room GetRoom(int id);

        Room CreateRoom(Room room);

        Room DeleteRoom(Room room);

        List<Room> ListRooms();

        Room EdditRoom(Room room);

        List<Seat> SeatsForSingleRoom(Room room);
    }
}
