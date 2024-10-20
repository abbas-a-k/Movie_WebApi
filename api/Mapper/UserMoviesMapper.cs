using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dto.Movies;
using api.Dto.UserMovies;
using api.Models;

namespace api.Mapper
{
    public static class UserMoviesMapper
    {
        public static UserMoviesDto ToUserMoviesDto(this Movies moviesModel)
        {
            return new UserMoviesDto
            {
                Id = moviesModel.Id,
                Name = moviesModel.Name,
                Genre = moviesModel.Genre,
                Country = moviesModel.Country,
                ReleasedIn = string
                .Format("{0}/{1}/{2}", moviesModel.ReleasedIn.Month
                , moviesModel.ReleasedIn.Day
                ,moviesModel.ReleasedIn.Year),
                IMDB = moviesModel.IMDB,
                InitialScore = (moviesModel.Comments.Select(element => element.Score).ToList()).Count>0 ? 
                Math.Round((moviesModel.Comments.Select(element => element.Score).ToList()).Average(),1)
                :0,
                Director = moviesModel.Directors.Name,
                Comments = moviesModel.Comments.Select(element => element.ToUserMoviesComentsDto()).ToList(),
                Actors = moviesModel.Actors.Select(element => element.Name).ToList()
            };
        }

        public static UserActorAndDirectorMoviesDto ToUserActorAndDirectorMoviesDto(this Movies moviesModel)
        {
            return new UserActorAndDirectorMoviesDto
            {
                Id = moviesModel.Id,
                Name = moviesModel.Name,
                Genre = moviesModel.Genre,
                Country = moviesModel.Country,
                ReleasedIn = string
                .Format("{0}/{1}/{2}", moviesModel.ReleasedIn.Month
                , moviesModel.ReleasedIn.Day
                ,moviesModel.ReleasedIn.Year),
                IMDB = moviesModel.IMDB,
            };
        }
    }
}