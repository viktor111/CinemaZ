using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlRoomServiceTest : DbContextSqlLite
    {
        private readonly ISqlRoomService _sqlRoomService;
        private readonly ISqlCinemaService _sqlCinemaService;

        public SqlRoomServiceTest()
        {
            _sqlRoomService = new SqlRoomService(_dbContext);
            _sqlCinemaService = new SqlCinemaService(_dbContext);
        }

        [TestMethod]
        public void CreateRoom_ShouldPersist()
        {
            //Arrange
            List<Room> rooms = new();

            Room room = new();
            room.Cinema = new();
            room.CinemaId = 1;
            room.MovieRoom = new List<MovieRoom>();
            room.Name = "Hello";

            Seat seat = new();
            seat.ColumnId = ColumnType.k;
            seat.RowId = RowType.A;
            seat.RoomId = room.Id;

            rooms.Add(room);

            Cinema cinema = new();
            cinema.Name = "w";
            cinema.Rooms = rooms;
            cinema.TimeClose = "w";
            cinema.City = CityType.California;

            _sqlCinemaService.CreateCinema(cinema);

            _dbContext.SaveChanges();

            //Act
            _sqlRoomService.CreateRoom(room);

            //Assert
            Room roomDb = _dbContext.Room.FirstOrDefault(r => r.Id == room.Id);

            Assert.IsNotNull(roomDb);
            Assert.AreEqual(room.Id, roomDb.Id);
            Assert.AreEqual(room.Name, roomDb.Name);
            Assert.AreEqual(room.Seats, roomDb.Seats);
            Assert.AreEqual(room.CinemaId, roomDb.CinemaId);
        }

        [TestMethod]
        public void ListRooms_ShouldWork()
        {

            //Arrange
            int roomExpextedCount = 2;

            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            Room room2 = new()
            {
                Name = "wwweqewe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 13,
                MovieRoom = new List<MovieRoom>()
            };

            //Act
            _dbContext.Room.Add(room);
            _dbContext.Room.Add(room2);

            _dbContext.SaveChanges();

            //Assert
            List<Room> rooms = _sqlRoomService.ListRooms();

            Assert.IsNotNull(rooms);
            Assert.AreEqual(roomExpextedCount, rooms.Count);
        }

        [TestMethod]
        public void GetRoomByName_ShouldWork()
        {
            //Arrange
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            //Act
            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            //Assert
            Room roomDb = _sqlRoomService.GetRoomByName(room.Name);

            Assert.IsNotNull(roomDb);
            Assert.AreEqual(room, roomDb);
        }

        [TestMethod]
        public void GetRoom_ShouldWork()
        {
            //Arrange
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            //Act
            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            //Assert
            Room roomDb = _sqlRoomService.GetRoom(room.Id);

            Assert.IsNotNull(roomDb);
            Assert.AreEqual(room, roomDb);
        }

        [TestMethod]
        public void EditRoom_shouldPersist()
        {
            //Arrange
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            //Act
            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            Room newRoom = new()
            {
                Id = room.Id,
                Name = "WIK3443",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 2,
                MovieRoom = new List<MovieRoom>()
            };

            _sqlRoomService.EdditRoom(newRoom);

            //Assert
            Room roomDb = _sqlRoomService.GetRoom(room.Id);

            Assert.AreEqual(newRoom.Name, roomDb.Name);
            Assert.AreEqual(newRoom.Cinema, newRoom.Cinema);
            Assert.AreEqual(newRoom.Seats, roomDb.Seats);
            Assert.AreEqual(newRoom.CinemaId, roomDb.CinemaId);
            Assert.AreEqual(newRoom.MovieRoom, roomDb.MovieRoom);
        }

        [TestMethod]
        public void DeleteRoom_ShouldWork()
        {
            //Arrange
            int expectedCount = 0;

            Room room = new()
            {
                Cinema = new Cinema(),
                Name = "www",
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            //Act
            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            _sqlRoomService.DeleteRoom(room);

            _dbContext.SaveChanges();

            //Assert
            List<Room> rooms = _sqlRoomService.ListRooms();

            Assert.AreEqual(expectedCount, rooms.Count);
        }


    }
}