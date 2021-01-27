using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Resources
{
    public class MovieResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GenreResource> Genres { get; set; }
    }
}
