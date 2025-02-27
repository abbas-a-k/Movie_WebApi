using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.UserMovies
{
    public class UserActorAndDirectorMoviesDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Country { get; set;} = string.Empty;
        public string ReleasedIn { get; set; } = string.Empty;
        public decimal IMDB { get; set; }
        public decimal InitialScore { set; get; }
        public string About { get; set; } = string.Empty;
    }
}