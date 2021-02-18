using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Room
    {
        public int Id { get; set; }

        public Cinema Cinema { get; set; }

        public int CinemaId { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<MovieRoom> MovieRoom { get; set; }
    }
}
