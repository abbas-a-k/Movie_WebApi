using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ActorsMovies
    {
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }
        public Actors Actors { get; set; }
        public Movies Movies { get; set; }
    }
}