using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminMovies;
using api.Models;

namespace api.Mapper
{
    public static class AdminMoviesMapper
    {
        public static Movies ToMoviesFromCreteNewMovieDto(this CreateNewMovieDto movieDto)
        {
            return new Movies
            {
                Name = movieDto.Name,
                Genre = movieDto.Genre,
                Country = movieDto.Country,
                ReleasedIn = (DateTime)movieDto.ReleasedIn,
                IMDB = movieDto.IMDB,
                DirectorsId = movieDto.DirectorId
            };
        }
    }
}