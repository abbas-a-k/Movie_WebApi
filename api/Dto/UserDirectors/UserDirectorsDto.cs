using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Movies;
using api.Dto.UserMovies;
using Microsoft.VisualBasic;

namespace api.Dto.directors
{
    public class UserDirectorsDto
    {
        public int Id { get; set; }
        public string ImageUrl { set; get; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string DateOfBirth { get; set; } = string.Empty;
        public bool Alive { get; set; } = true;
        public string BirthPlace { get; set; } = string.Empty;
        public string About { get; set;} = string.Empty;
        public List<UserActorAndDirectorMoviesDto> Movies { get; set; } = new List<UserActorAndDirectorMoviesDto>();
        
    }
}