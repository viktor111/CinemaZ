using CinemaZ.Data;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Modelsd;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Service
{
    public class SqlRoomService : ISqlRoomService
    {
        private ApplicationDbContext _dbContext;
        private SqlSeatService _sqlSeatService;

        public SqlRoomService
            (
            ApplicationDbContext dbContext,
            SqlSeatService sqlSeatService
            )
        {
            _dbContext = dbContext;
            _sqlSeatService = sqlSeatService;
        }

        public Room CreateRoom(Room room)
        {
            List<Seat> newSeats = _sqlSeatService.GenerateSeats(room);

            room.Seats = newSeats;

            _dbContext.Room.Add(room);

            //_dbContext.SaveChanges();

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
