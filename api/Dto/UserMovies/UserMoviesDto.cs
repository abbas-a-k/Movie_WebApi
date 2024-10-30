using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Actors;
using api.Dto.directors;
using api.Dto.UserComments;
using api.Models;

namespace api.Dto.Movies
{
    public class UserMoviesDto
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
        public string? Director { get; set; }
        public List<UserMoviesComentsDto> Comments { get; set; } = new List<UserMoviesComentsDto>();
        public List<string> Actors { get; set; } = new List<string>();
    }
}