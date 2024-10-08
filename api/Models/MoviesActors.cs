using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace api.Models
{
    public class MoviesActors
    {
        public int MoviesId { get; set; }
        public int ActorsId { get; set; }
        public Movies Movies { get; set; }
        public Actors Actors { get; set; }
    }
}