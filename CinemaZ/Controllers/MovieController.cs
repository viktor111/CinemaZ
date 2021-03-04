using CinemaZ.Helpers;
using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CinemaZ.Controllers
{
    public class MovieController : Controller
    {
        private readonly ISqlMovieService _sqlMovieService;
        private readonly ISqlPremiereService _sqlPremiereService;
        private readonly ISqlRoomService _sqlRoomService;
        private readonly ISqlMovieRoomService _sqlMovieRoomService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController
           (
            ISqlMovieService sqlMovieService,
            ISqlPremiereService sqlPremiereService,
            ISqlRoomService sqlRoomService,
            ISqlMovieRoomService sqlMovieRoomService,
            IWebHostEnvironment webHostEnvironment)
        {
            _sqlMovieService = sqlMovieService;
            _sqlPremiereService = sqlPremiereService;
            _sqlRoomService = sqlRoomService;
            _sqlMovieRoomService = sqlMovieRoomService;
            _webHostEnvironment = webHostEnvironment;
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

            ImageUpload imageUpload = new(_webHostEnvironment);

            string uniqueFilename = imageUpload.UploadedFile(model.Picture);

            //string uniqueFileName = 

            Premiere premiere = new();

            premiere.Discount = discountedPrice;
            premiere.PremiereDate = model.ReleaseDate;
            premiere.EndDate = model.ReleaseDate.AddDays(model.DaysPremiere);

            _sqlPremiereService.CreatePremiere(premiere);

            Movie movie = new();

            movie.Picture = uniqueFilename;
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

        [HttpGet]
        public IActionResult ListMovies()
        {
            List<MovieViewModel> model = new List<MovieViewModel>();

            ICollection<Movie> movies = _sqlMovieService.ListMovies();

            foreach (Movie movie in movies)
            {
                MovieViewModel movieViewModel = new();

                movieViewModel.Category = movie.Category;
                movieViewModel.Name = movie.Name;
                movieViewModel.PictureSrc = movie.Picture;
                movieViewModel.Price = movie.Price;

                model.Add(movieViewModel);
            }

            return View(model);
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