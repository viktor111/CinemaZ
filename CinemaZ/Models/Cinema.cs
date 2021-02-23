using CinemaZ.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
