using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string ImageUrl { set; get; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Alive { get; set; } = true;
        public string BirthPlace { get; set; } = string.Empty;
        public string About { get; set;} = string.Empty;
        public List<Movies> Movies { get; set; } = new List<Movies>();
        public List<MoviesActors> MoviesActors { get; set; }
    }
}