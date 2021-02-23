using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            List<Room> newRooms = new();

            Cinema cinema = new();

            cinema.Name = model.Name;
            cinema.TimeClose = model.TimeClose;
            cinema.Adress = model.Adress;
            Room room = new();
            for (int i = 0; i < model.RoomCount; i++)
            {
                

                room.Name = i.ToString();
                room.Cinema = cinema;                
                
                _sqlRoomService.CreateRoom(room);

                newRooms.Add(room);

                room = new();
            }

            cinema.Rooms = newRooms;

            _sqlCinemaService.CreateCinema(cinema);

            return RedirectToAction(nameof(CreateCinema));
        }
    }
}
