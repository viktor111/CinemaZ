using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Seat
    {
        public int Id { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }
    }
}
