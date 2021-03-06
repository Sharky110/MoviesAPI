using System;
using System.Collections.Generic;

namespace Movies.Core.Models
{
    public class Movie
    {
        public Movie() {}
        public Movie(string name, string tagline, DateTime release, string country, string director)
        {
            (Name, Tagline, Release, Country, Director) = (name, tagline, release, country, director);
            Genres = new List<Genre>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public string Tagline { get; set; }
        public DateTime Release { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
    }
}
