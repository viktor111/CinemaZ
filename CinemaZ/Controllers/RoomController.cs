using CinemaZ.Models;
using CinemaZ.Service;
using Microsoft.AspNetCore.Mvc;

namespace CinemaZ.Controllers
{
    public class RoomController : Controller
    {
        private readonly ISqlCinemaService _sqlCinemaService;
        private readonly ISqlRoomService _sqlRoomService;

        public RoomController
            (
            ISqlCinemaService sqlCinemaService,
            ISqlRoomService sqlRoomService
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
