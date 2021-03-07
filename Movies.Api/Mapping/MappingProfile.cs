using AutoMapper;
using Movies.Api.Resources;
using Movies.Core.Models;

namespace Movies.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Movie, MovieResource>();
            CreateMap<Genre, GenreResource>();

            // Resource to Domain
            CreateMap<MovieResource, Movie>();
            CreateMap<GenreResource, Genre>();
        }
    }
}
