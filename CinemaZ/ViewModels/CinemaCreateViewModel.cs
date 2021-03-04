using CinemaZ.Models.Types;

namespace CinemaZ.ViewModels
{
    public class CinemaCreateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CityType City { get; set; }

        public string Adress { get; set; }

        public string TimeClose { get; set; }

        public int RoomCount { get; set; }
    }
}
