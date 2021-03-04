using CinemaZ.Controllers;
using CinemaZ.Models;
using CinemaZ.Models.Types;
using CinemaZ.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CinemaZ.Test.Controllers
{
    [TestClass]
    public class RoomControllerTest : DbContextSqlLite
    {
        private readonly ISqlRoomService _sqlRoomService;
        private readonly ISqlCinemaService _sqlCinemaService;
        private readonly RoomController _roomController;

        public RoomControllerTest()
        {
            _sqlRoomService = new SqlRoomService(_dbContext);
            _sqlCinemaService = new SqlCinemaService(_dbContext);
            _roomController = new(_sqlCinemaService, _sqlRoomService);
        }

        [TestMethod]
        public void RoomDetails_ShouldBeValid()
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
            ViewResult result = _roomController.RoomDetails(room.Id) as ViewResult;
            Room model = result.Model as Room;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Room));
        }
    }
}
