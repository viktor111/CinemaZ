using System;

namespace CinemaZ.Models
{
    public class Premiere
    {
        public int Id { get; set; }

        public DateTime PremiereDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal? Discount { get; set; }

        public Movie Movie { get; set; }
    }
}
