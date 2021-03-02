using System;
using CinemaZ.Controllers;
using CinemaZ.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Controllers
{
    [TestClass]
    public class RoomControllerTest : DbContextSqlLite
    {
        private readonly SqlRoomService _sqlRoomService;
        private readonly SqlCinemaService _sqlCinemaService;
        private readonly RoomController _roomController;

        public RoomControllerTest()
        {
            _sqlRoomService = new(_dbContext);
            _sqlCinemaService = new(_dbContext);
            _roomController = new(_sqlCinemaService, _sqlRoomService);
        }

        [TestMethod]
        public void Room_ShouldReturnView()
        {

        }
    }
}
