﻿using CinemaZ.Models.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaZ.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieRatingType MovieRating { get; set; }

        public CategoryType Category { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int DaysPremiere { get; set; }

        public decimal DiscountPercent { get; set; }

        [Required(ErrorMessage = "Please choose image")]
        public IFormFile Picture { get; set; }

        public string PictureSrc { get; set; }
    }
}