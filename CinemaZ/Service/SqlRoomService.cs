using CinemaZ.Data;
using CinemaZ.Models;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Service
{
    public class SqlRoomService : ISqlRoomService
    {
        private readonly ApplicationDbContext _dbContext;

        public SqlRoomService
            (
            ApplicationDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public Room CreateRoom(Room room)
        {
            SqlSeatService sqlSeatService = new SqlSeatService(_dbContext);
            
            List<Seat> newSeats = sqlSeatService.GenerateSeats(room);

            room.Seats = newSeats;

            _dbContext.Room.Add(room);

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
            Room roomToEdit = _dbContext.Room.FirstOrDefault(r => r.Id == room.Id);
    
            roomToEdit.MovieRoom = room.MovieRoom;
            roomToEdit.Name = room.Name;
            roomToEdit.Seats = room.Seats;
            roomToEdit.CinemaId = room.CinemaId;
            roomToEdit.Cinema = roomToEdit.Cinema;

            return new Room();
        }

        public Room GetRoom(int id)
        {
            return _dbContext.Room.FirstOrDefault(r => r.Id == id);
        }

        public Room GetRoomByName(string name)
        {
            return _dbContext.Room.FirstOrDefault(r => r.Name == name);
        }

        public List<Room> ListRooms()
        {
            return _dbContext.Room.OrderBy(r => r.Name).ToList();
        }

        public List<Seat> SeatsForSingleRoom(Room room)
        {
            List<Seat> seats = new();

            seats = _dbContext.Seat.
                Where(s => s.RoomId == room.Id).
                OrderBy(s => s.RowId).
                ThenBy(s => s.ColumnId).
                ToList();

            return seats;
        }
    }
}
