using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class MovieRoom
    {
        public int MovieId { get; set; }

        public int RoomId { get; set; }

        public Movie Movie { get; set; }

        public Room Room { get; set; }

        public DateTime AirTime { get; set; }
    }
}
