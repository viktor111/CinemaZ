using Microsoft.AspNetCore.Identity;

namespace CinemaZ.Models
{
    public class AppUser : IdentityUser
    {
        public int MoviesWatched { get; set; }
    }
}
