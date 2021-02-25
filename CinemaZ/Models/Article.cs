using System;

namespace CinemaZ.Models
{
    public class Article
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public int Views { get; set; }
    }
}
