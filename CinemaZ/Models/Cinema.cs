using CinemaZ.Models.Types;
using System.Collections.Generic;

namespace CinemaZ.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public CityType City { get; set; }

        public string Adress { get; set; }

        public string TimeClose { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
