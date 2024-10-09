using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Movies;
using api.Models;

namespace api.Mapper
{
    public static class MoviesMapper
    {
        public static MoviesDto ToMovieDto(this Movies moviesModel)
        {
            return new MoviesDto
            {
                Name = moviesModel.Name,
                Genre = moviesModel.Genre,
                Country = moviesModel.Country,
                CreatedOn = string
                .Format("{0}/{1}/{2}", moviesModel.CreatedOn.Month
                , moviesModel.CreatedOn.Day
                ,moviesModel.CreatedOn.Year),
                IMDB = moviesModel.IMDB
            };
        }
    }
}