using System.Collections.Generic;

namespace Movies.Api.Resources
{
    public class MovieResource
    {
        public string Name { get; set; }
        public string Tagline { get; set; }
        public ICollection<GenreResource> Genres { get; set; }
    }
}
