using CinemaZ.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaZ.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // ToDo: Add movie lenght prop

        public string Name { get; set; }

        public string Picture { get; set; }

        public MovieRatingType MovieRating { get; set; }

        public int AllowedAge
        {
            set
            {
                switch (MovieRating)
                {
                    case MovieRatingType.A:
                        AllowedAge = 1;
                        return;
                    case MovieRatingType.B:
                        AllowedAge = 12;
                        return;
                    case MovieRatingType.C:
                        AllowedAge = 16;
                        return;
                    case MovieRatingType.D:
                        AllowedAge = 18;
                        return;
                    default:
                        AllowedAge = 1;
                        return;
                }
            }
        }

        public CategoryType Category { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public Premiere Premiere { get; set; }

        public int? PremiereId { get; set; }

        public ICollection<MovieRoom> MovieRoom { get; set; }

    }
}
