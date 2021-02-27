using System;
using System.Collections.Generic;
using CinemaZ.Models;
using CinemaZ.Models.Types;

namespace CinemaZ.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MovieRatingType MovieRating{ get; set; }
        
        public CategoryType Category { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int DaysPremiere { get; set; }

        public decimal DiscountPercent { get; set; }

    }
}