using CinemaZ.Models;
using CinemaZ.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Controllers
{
    public class RoomController : Controller
    {
        private readonly SqlCinemaService _sqlCinemaService;
        private readonly SqlRoomService _sqlRoomService;

        public RoomController
            (
            SqlCinemaService sqlCinemaService,
            SqlRoomService sqlRoomService
            )
        {
            _sqlCinemaService = sqlCinemaService;
            _sqlRoomService = sqlRoomService;
        }

        public IActionResult Room(int id)
        {
            Room room = _sqlRoomService.GetRoom(id);
            room.Seats = _sqlRoomService.SeatsForSingleRoom(room);

            return View(room);
        }
    }
}
