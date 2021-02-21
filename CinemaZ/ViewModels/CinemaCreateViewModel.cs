using CinemaZ.Models;
using CinemaZ.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.ViewModels
{
    public class CinemaCreateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityType City{ get; set; }

        public string Adress { get; set; }

        public string TimeClose { get; set; }

        public int RoomCount { get; set; }
    }
}
