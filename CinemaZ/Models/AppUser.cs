using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class AppUser : IdentityUser
    {
        public int MoviesWatched { get; set; }
    }
}
