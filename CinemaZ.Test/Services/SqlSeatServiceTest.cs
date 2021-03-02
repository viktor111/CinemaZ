﻿using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlSeatServiceTest : DbContextSqlLite
    {
        private readonly SqlSeatService _sqlSeatService;

        public SqlSeatServiceTest()
        {
            _sqlSeatService = new(_dbContext);
          
        }

        [TestMethod]
        public void ListSeats_CountShouldBeMoreThanOne()
        {
            Room room = new()
            {
                Cinema = new Cinema(),
                Name = "w",
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };
            
            room.Seats = _sqlSeatService.GenerateSeats(room);
            
            _dbContext.Room.Add(room);

            List<Seat> seats = room.Seats.ToList();

            bool seatCountBiggerThanOne = seats.Count >= 1;

            Assert.IsTrue(seatCountBiggerThanOne);
        }

        [TestMethod]
        public void ListSeats_ShouldNotBeNull()
        {
            Room room = new()
            {
                Cinema = new Cinema(),
                Name = "w",
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };
            
            room.Seats = _sqlSeatService.GenerateSeats(room);
            
            _dbContext.Room.Add(room);

            List<Seat> seats = room.Seats.ToList();

            Assert.IsNotNull(seats);
        }

        [TestMethod]
        public void GenerateSeats_ShouldGenerateRightColAndRow()
        {
            Room room = new()
            {
                Cinema = new Cinema(),
                Name = "w",
                CinemaId = 1,
                MovieRoom = new List<MovieRoom>()
            };
            
            room.Seats = _sqlSeatService.GenerateSeats(room);
            
            _dbContext.Room.Add(room);

            List<Seat> seats = room.Seats.ToList();

            Assert.AreEqual(RowType.A,seats[0].RowId);
            Assert.AreEqual(ColumnType.k, seats[0].ColumnId);
        }
    }
}