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
            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            return new Room();
        }

        public Room DeleteRoom(Room room)
        {
            _dbContext.Remove(room);

            _dbContext.SaveChanges();

            return new Room();
        }

        public Room EdditRoom(Room room)
        {
            Room roomToEdit = _dbContext.Room.Where(r => r.Id == room.Id).FirstOrDefault();

            roomToEdit.MovieRoom = room.MovieRoom;
            roomToEdit.Name = room.Name;
            roomToEdit.Seats = room.Seats;
            roomToEdit.CinemaId = room.CinemaId;
            roomToEdit.Cinema = roomToEdit.Cinema;

            return new Room();
        }

        public Room GetRoom(int id)
        {
            return _dbContext.Room.Where(r => r.Id == id).FirstOrDefault();
        }

        public List<Room> ListRooms()
        {
            return _dbContext.Room.OrderBy(r => r.Name).ToList();
        }
    }
}
