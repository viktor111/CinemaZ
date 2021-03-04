using CinemaZ.Models;
using System.Collections.Generic;

namespace CinemaZ.ViewModels
{
    public class CinemaDetailsModel
    {
        public string TimeClose { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
