using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.directors;
using api.Models;

namespace api.Mapper
{
    public static class UserDirectorsMapper
    {
        public static UserDirectorsDto ToUserDirectorsDto(this Directors directorsModel)
        {
            return new UserDirectorsDto
            {
                ImageUrl = directorsModel.ImageUrl,
                Name = directorsModel.Name,
                Age = directorsModel.Age,
                DateOfBirth = string
                .Format("{0}/{1}/{2}", directorsModel.DateOfBirth.Month
                , directorsModel.DateOfBirth.Day
                ,directorsModel.DateOfBirth.Year),
                Alive = directorsModel.Alive,
                BirthPlace = directorsModel.BirthPlace,
                About = directorsModel.About,
                Movies = directorsModel.Movies.Select(element => element.ToUserActorAndDirectorMoviesDto()).ToList()
            };
        }
    }
}