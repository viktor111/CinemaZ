﻿using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CinemaZ.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ISqlCinemaService _sqlCinemaService;
        private readonly ISqlRoomService _sqlRoomService;

        public CinemaController
            (
            ISqlCinemaService sqlCinemaService,
            ISqlRoomService sqlRoomService
            )
        {
            _sqlCinemaService = sqlCinemaService;
            _sqlRoomService = sqlRoomService;
        }

        [HttpGet]
        public IActionResult CinemaDetail(int id)
        {
            Cinema cinema = _sqlCinemaService.GetCinema(id);

            CinemaDetailsModel viewModel = new();

            viewModel.Rooms = _sqlCinemaService.ListRooms(cinema);
            viewModel.TimeClose = cinema.TimeClose;
            viewModel.Name = cinema.Name;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ListCinema()
        {
            CinemaListViewModel viewModel = new();

            viewModel.Cinemas = _sqlCinemaService.ListCinemas();

            return View(viewModel);
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


                room.Name = $"{i}:{cinema.Name}";
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
