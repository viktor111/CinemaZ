using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
