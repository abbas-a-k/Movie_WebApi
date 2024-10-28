using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminDirectors;
using api.Models;

namespace api.Mapper
{
    public static class AdminDirectorsMapper
    {
        public static Directors ToDirectorsFromCreatrNewDirectorDto(this CreateNewDirectorDto directorDto)
        {
            return new Directors
            {
                ImageUrl = directorDto.ImageUrl,
                Name = directorDto.Name,
                Age = directorDto.Age,
                DateOfBirth = directorDto.DateOfBirth,
                Alive = directorDto.Alive,
                BirthPlace = directorDto.BirthPlace,
                About = directorDto.About
            };
        }
    }
}