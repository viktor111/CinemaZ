using System.Collections.Generic;
using System.Net.Sockets;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlRoomServiceTest : DbContextSqlLite
    {
        private readonly SqlRoomService _sqlRoomService;

        public SqlRoomServiceTest()
        {
            _sqlRoomService = new(_dbContext);
        }

        [TestMethod]
        public void ListRooms_ShouldWork()
        {
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

            _dbContext.Room.Add(room);
            _dbContext.Room.Add(room2);

            _dbContext.SaveChanges();

            int roomExpextedCount = 2;
            
            List<Room> rooms = _sqlRoomService.ListRooms();

            Assert.IsNotNull(rooms);
            Assert.AreEqual(roomExpextedCount, rooms.Count);
        }
        
        [TestMethod]
        public void GetRoomByName_ShouldWork()
        {
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            Room roomDb = _sqlRoomService.GetRoomByName(room.Name);
            
            Assert.IsNotNull(roomDb);
            Assert.AreEqual(room, roomDb);
        }
        
        [TestMethod]
        public void GetRoom_ShouldWork()
        {
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            Room roomDb = _sqlRoomService.GetRoom(room.Id);
            
            Assert.IsNotNull(roomDb);
            Assert.AreEqual(room, roomDb);
        }

        [TestMethod]
        public void EditRoom_shouldPersist()
        {
            Room room = new()
            {
                Name = "wwwe",
                Cinema = new Cinema(),
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

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
            int expectedCount = 0;
            
            Room room = new()
            {
                Cinema = new Cinema(),
                Name = "www",
                Seats = new List<Seat>(),
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };

            _dbContext.Room.Add(room);

            _dbContext.SaveChanges();

            _sqlRoomService.DeleteRoom(room);
            
            _dbContext.SaveChanges();

            List<Room> rooms = _sqlRoomService.ListRooms();
            
            Assert.AreEqual(expectedCount,rooms.Count);
        }
        
        
    }
}