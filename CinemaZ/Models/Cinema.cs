using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
