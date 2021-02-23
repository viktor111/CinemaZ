using CinemaZ.Modelsd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Cinema Cinema { get; set; }

        public int CinemaId { get; set; }

        //[Range(10, 1000,
        //ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        //public int RowCount { get; set; }

        //[Range(10, 1000,
        //ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        //public int ColCount { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<MovieRoom> MovieRoom { get; set; }
    }
}
