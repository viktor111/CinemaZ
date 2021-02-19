using CinemaZ.Data;
using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Service
{
    public class SqlRoomService : ISqlRoomService
    {
        private ApplicationDbContext _dbContext;

        public SqlRoomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room DeleteRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room EdditRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public List<Room> ListRooms()
        {
            throw new NotImplementedException();
        }
    }
}
