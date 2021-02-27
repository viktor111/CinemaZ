using System;
using CinemaZ.Models;
using CinemaZ.Service;
using CinemaZ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CinemaZ.Controllers
{
    public class MovieController : Controller
    {
        private readonly SqlMovieService _sqlMovieService;
        private readonly SqlPremiereService _sqlPremiereService;
        
        public MovieController(SqlMovieService sqlMovieService, SqlPremiereService sqlPremiereService)
        {
            _sqlMovieService = sqlMovieService;
            _sqlPremiereService = sqlPremiereService;
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
    }
}