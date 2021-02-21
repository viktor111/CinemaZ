using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaZ.Controllers
{
    public class CinemaController : Controller
    {
        private readonly SqlCinemaService _sqlCinemaService;
        private readonly SqlRoomService _sqlRoomService;

        public CinemaController
            (
            SqlCinemaService sqlCinemaService,
            SqlRoomService sqlRoomService
            )
        {
            _sqlCinemaService = sqlCinemaService;
            _sqlRoomService = sqlRoomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCinema()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult CreateCinema(CinemaCreateViewModel model)
        {
            Cinema cinema = new();

            cinema.Name = model.Name;
            cinema.TimeClose = model.TimeClose;
            cinema.Adress = model.Adress;         

            for (int i = 0; i < model.RoomCount; i++)
            {
                Room room = new();

                room.Name = i.ToString();
                room.Cinema = cinema;
                
                _sqlRoomService.CreateRoom(room);

                cinema.Rooms.Add(room);
            }

            _sqlCinemaService.CreateCinema(cinema);

            return RedirectToAction(nameof(Index));
        }
    }
}
