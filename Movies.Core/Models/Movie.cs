using System;

namespace Movies.Core.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Tagline { get; set; }
        public DateTime Release { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
    }
}
