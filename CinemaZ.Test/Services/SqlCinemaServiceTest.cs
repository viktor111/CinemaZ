using System;
using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlCinemaServiceTest : DbContextSqlLite
    {

        [TestMethod]
        public void ListCinema_ShouldListCinemas()
        {
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

            _dbContext.Cinema.Add(cinemaDto);
            _dbContext.Cinema.Add(cinemaDto2);

            _dbContext.SaveChanges();

            List<Cinema> cinemas = _dbContext.Cinema.OrderBy(c => c.City).ToList();

            Assert.IsNotNull(cinemas);
            Assert.IsInstanceOfType(cinemas, typeof(List<Cinema>));
            Assert.AreEqual(2, cinemas.Count);
        }

        [TestMethod]
        public void ListRooms_ShouldListRooms()
        {
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

            _dbContext.Cinema.Add(cinemaDto);
            _dbContext.SaveChanges();

            List<Room> rooms = _dbContext.Room.Where(r => r.Id == cinemaDto.Id).ToList();
            int singleRoomId = rooms[0].Id;
            
            Assert.IsNotNull(rooms);
            Assert.AreEqual(singleRoomId, cinemaDto.Id);
        }

        [TestMethod]
        public void DeleteCinema_ShouldDelete()
        {
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _dbContext.Add(cinemaDto);

            _dbContext.SaveChanges();

            _dbContext.Remove(cinemaDto);

            _dbContext.SaveChanges();

            Cinema cinema = _dbContext.Cinema.FirstOrDefault(c => c.Id == cinemaDto.Id);

            Assert.IsNull(cinema);
        }

        [TestMethod]
        public void EditCinema_ShouldPersist()
        {
            int id = 1;
            
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _dbContext.Add(cinemaDto);
            
            _dbContext.SaveChanges();
            
            Cinema newCinema= new()
            {
                Id = 1,
                Adress = "Some address 2",
                City = CityType.Sydney,
                Name = "Some Name 2",
                Rooms = new List<Room>(),
                TimeClose = "Some Time 2"
            };

            Cinema cinema = _dbContext.Cinema.FirstOrDefault(c => c.Id == cinemaDto.Id);

            cinema.Adress = newCinema.Adress;
            cinema.City = newCinema.City;
            cinema.Name = newCinema.Name;
            cinema.Rooms = newCinema.Rooms;
            cinema.TimeClose = newCinema.TimeClose;

            _dbContext.SaveChanges();
            
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
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _dbContext.Cinema.Add(cinemaDto);
            
            _dbContext.SaveChanges();
            
            Cinema cinemaGet = _dbContext.Cinema.FirstOrDefault(c => c.Id == cinemaDto.Id);
            
            Assert.AreEqual(cinemaDto, cinemaGet);
        }
        
        [TestMethod]
        public void CreateCinema_ShouldGenerateId()
        {
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _dbContext.Cinema.Add(cinemaDto);

            _dbContext.SaveChanges();
            
            Assert.AreNotEqual(0, cinemaDto.Id);
        }
        
        [TestMethod]
        public void CreateCinema_ShouldPersist()
        {
            Cinema cinemaDto = new()
            {
                Adress = "Some adress",
                City = CityType.California,
                Name = "Some Name",
                Rooms = new List<Room>(),
                TimeClose = "Some Time"
            };

            _dbContext.Cinema.Add(cinemaDto);

            _dbContext.SaveChanges();
            
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