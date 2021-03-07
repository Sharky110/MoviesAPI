using System;
using System.Collections.Generic;

namespace Movies.Core.Models
{
    public class Genre
    {
        public Genre()
        {
            Movies = new List<Movie>();
        }

        public Genre(string name)
        {
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
