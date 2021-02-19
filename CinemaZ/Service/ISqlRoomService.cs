using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public interface ISqlRoomService
    {
        Room GetRoom(int id);

        Room CreateRoom(Room room);

        Room DeleteRoom(Room room);

        List<Room> ListRooms();

        Room EdditRoom(Room room);
    }
}
