using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Movies
{
    public class MoviesDto
    {
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Country { get; set;} = string.Empty;
        public string ReleasedIn { get; set; } = string.Empty;
        public decimal IMDB { get; set; }
    }
}