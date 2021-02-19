using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaZ.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public CategoryType Category { get; set; }

        public Premiere Premiere { get; set; }

        public int? PremiereId { get; set; }

        public ICollection<MovieRoom> MovieRoom { get; set; }

    }
}
