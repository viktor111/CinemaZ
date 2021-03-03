using System;
using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlCinemaServiceTest : DbContextSqlLite
    {
        private readonly ISqlCinemaService _sqlCinemaService;
        public SqlCinemaServiceTest()
        {
            _sqlCinemaService = new SqlCinemaService(_dbContext);
        }

        [TestMethod]
        public void CreateCinema_ShouldCreateValid()
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

            //Act
            _sqlCinemaService.CreateCinema(cinema);

            _dbContext.SaveChanges();

            //Assert
            Cinema cinemaDb = _dbContext.Cinema.FirstOrDefault(c => c.Id == cinema.Id);

            Assert.IsNotNull(cinemaDb);
            Assert.AreEqual(cinema.Id, cinemaDb.Id);
            Assert.AreEqual(cinema.Name, cinemaDb.Name);
            Assert.AreEqual(cinema.Rooms, cinemaDb.Rooms);
            Assert.AreEqual(cinema.City, cinemaDb.City);
        }

        [TestMethod]
        public void ListCinema_ShouldListCinemas()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };
            Cinema cinemaDto2 = new()
            {
                Adress = "Some adress2",
                City = CityType.Stara_Zagora,
                Name = "Some Name2",
                Rooms = new List<Room>(),
                TimeClose = "Some Time2"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);
            _sqlCinemaService.CreateCinema(cinemaDto2);

            //Assert
            List<Cinema> cinemas = _sqlCinemaService.ListCinemas();

            Assert.IsNotNull(cinemas);
            Assert.IsInstanceOfType(cinemas, typeof(List<Cinema>));
            Assert.AreEqual(2, cinemas.Count);
        }

        [TestMethod]
        public void ListRooms_ShouldListRooms()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>()
                {
                    new ()
                    {
                        Cinema = new Cinema(),
                        Id = 1,
                        Name = "R",
                        Seats = new List<Seat>(),
                        CinemaId = 1,
                        MovieRoom = new List<MovieRoom>()
                    },
                    new ()
                    {
                        Cinema = new Cinema(),
                        Id = 2,
                        Name = "R",
                        Seats = new List<Seat>(),
                        CinemaId = 1,
                        MovieRoom = new List<MovieRoom>()
                    }
                },
                TimeClose = "Some Time"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);

            //Assert
            List<Room> rooms = _sqlCinemaService.ListRooms(cinemaDto);
            int singleRoomId = rooms[0].Id;
            
            Assert.IsNotNull(rooms);
            Assert.AreEqual(singleRoomId, cinemaDto.Id);
        }

        [TestMethod]
        public void DeleteCinema_ShouldDelete()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);

            _sqlCinemaService.DeleteCinema(cinemaDto);

            //Assert
            Cinema cinema = _sqlCinemaService.GetCinema(cinemaDto.Id);

            Assert.IsNull(cinema);
        }

        [TestMethod]
        public void EditCinema_ChangesShouldPersist()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _sqlCinemaService.CreateCinema(cinemaDto);

            Cinema newCinema= new()
            {
                Id = 1,
                Adress = "Some address 2",
                City = CityType.Sydney,
                Name = "Some Name 2",
                Rooms = new List<Room>(),
                TimeClose = "Some Time 2"
            };

            //Act
            _sqlCinemaService.EdditCinema(newCinema);

            //Assert
            Cinema cinema = _sqlCinemaService.GetCinema(newCinema.Id);
            
            Assert.AreEqual(newCinema.Id, cinema.Id);
            Assert.AreEqual(newCinema.Adress, cinema.Adress);
            Assert.AreEqual(newCinema.City, cinema.City);
            Assert.AreEqual(newCinema.Name, cinema.Name);
            Assert.AreEqual(newCinema.Rooms, cinema.Rooms);
            Assert.AreEqual(newCinema.TimeClose, cinema.TimeClose);
        }
        
        [TestMethod]
        public void GetCinema_ShouldGetCinema()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);

            //Assert
            Cinema cinemaGet = _sqlCinemaService.GetCinema(cinemaDto.Id);
            
            Assert.AreEqual(cinemaDto, cinemaGet);
        }
        
        [TestMethod]
        public void CreateCinema_ShouldGenerateId()
        {
            //Arange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);

            //Assert
            Assert.AreNotEqual(0, cinemaDto.Id);
        }
        
        [TestMethod]
        public void CreateCinema_ShouldPersist()
        {
            //Arrange
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            //Act
            _sqlCinemaService.CreateCinema(cinemaDto);


            //Assert
            Assert.AreEqual(cinemaDto, _dbContext.Cinema.Find(cinemaDto.Id));
            Assert.AreEqual(1, _dbContext.Cinema.Count());
        }

        [TestMethod]
        public void EnsureTableCreated()
        {
            Assert.IsFalse(_dbContext.Cinema.Any());
        }
    }
}