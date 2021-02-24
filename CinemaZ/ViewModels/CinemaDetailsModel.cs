using CinemaZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.ViewModels
{
    public class CinemaDetailsModel
    {
        public string TimeClose { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
