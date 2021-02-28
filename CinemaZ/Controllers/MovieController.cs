using System;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CinemaZ.Controllers
{
    public class MovieController : Controller
    {
        private readonly SqlMovieService _sqlMovieService;
        private readonly SqlPremiereService _sqlPremiereService;
        private readonly SqlRoomService _sqlRoomService;
        private readonly SqlMovieRoomService _sqlMovieRoomService;
        
        public MovieController
           (
            SqlMovieService sqlMovieService, 
            SqlPremiereService sqlPremiereService, 
            SqlRoomService sqlRoomService, 
            SqlMovieRoomService sqlMovieRoomService
            )
        {
            _sqlMovieService = sqlMovieService;
            _sqlPremiereService = sqlPremiereService;
            _sqlRoomService = sqlRoomService;
            _sqlMovieRoomService = sqlMovieRoomService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieViewModel model)
        {
            decimal discountCalc = model.DiscountPercent / 100;
            decimal discountedPrice = model.Price - (discountCalc * model.Price);
            
            Premiere premiere = new();
           
            premiere.Discount = discountedPrice;
            premiere.PremiereDate = model.ReleaseDate;
            premiere.EndDate = model.ReleaseDate.AddDays(model.DaysPremiere);
            
            _sqlPremiereService.CreatePremiere(premiere);
            
            Movie movie = new();
            
            // Todo: Picture upload
            movie.Name = model.Name;
            movie.Price = model.Price;
            movie.ReleaseDate = model.ReleaseDate;
            movie.MovieRating = model.MovieRating;
            movie.Category = model.Category;
            movie.PremiereId = premiere.Id;

            _sqlMovieService.CreateMovie(movie);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddMovieToRoom()
        {
            MovieToRoomViewModel viewModel = new();

            viewModel.Movies = new SelectList(_sqlMovieService.ListMovies().Select(movie => movie.Name));
            viewModel.Rooms = new SelectList(_sqlRoomService.ListRooms().Select(room => room.Name));
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMovieToRoom(MovieToRoomViewModel model)
        {
            string selectedMovie = model.MovieName;
            string selectedRoom = model.RoomName;

            Movie movie = _sqlMovieService.GetMovieByName(selectedMovie);
            Room room = _sqlRoomService.GetRoomByName(selectedRoom);

            MovieRoom movieRoom = new();

            movieRoom.Movie = movie;
            movieRoom.Room = room;
            movieRoom.MovieId = movie.Id;
            movieRoom.RoomId = room.Id;
            movieRoom.AirTime = model.AirTime;
            
            _sqlMovieRoomService.AddMovieToRoom(movieRoom);

            return RedirectToAction(nameof(Index));
        }
    }
}