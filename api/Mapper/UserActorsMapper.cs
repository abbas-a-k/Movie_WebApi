using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Actors;
using api.Models;

namespace api.Mapper
{
    public static class ActorsMapper
    {
        public static UserActorsDto ToUserActorsDto(this Actors actorsModel)
        {
            return new UserActorsDto
            {
                ImageUrl = actorsModel.ImageUrl,
                Name = actorsModel.Name,
                Age = actorsModel.Age,
                DateOfBirth = string
                .Format("{0}/{1}/{2}", actorsModel.DateOfBirth.Month
                , actorsModel.DateOfBirth.Day
                ,actorsModel.DateOfBirth.Year),
                Alive = actorsModel.Alive,
                BirthPlace = actorsModel.BirthPlace,
                About = actorsModel.About,
                Movies = actorsModel.Movies.Select(element => element.ToUserActorAndDirectorMoviesDto()).ToList()
            };
        }
    }
}