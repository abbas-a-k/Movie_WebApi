using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminActors;
using api.Models;

namespace api.Mapper
{
    public static class AdminActorsMapper
    {
        public static Actors ToActorsFromCreateNewActorsDto(this CreateNewActorsDto actorsDto)
        {
            return new Actors
            {
                ImageUrl = actorsDto.ImageUrl,
                Name = actorsDto.Name,
                Age = actorsDto.Age,
                DateOfBirth = actorsDto.DateOfBirth,
                Alive = actorsDto.Alive,
                BirthPlace = actorsDto.BirthPlace,
                About = actorsDto.About
            };
        }
    }
}