using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Country { get; set;} = string.Empty;
        public DateTime ReleasedIn { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal IMDB { get; set; }
        public int? DirectorsId { set; get; }
        public Directors? Directors { get; set;}
        public List<Comments> Comments { get; set; } = new List<Comments>();
        public List<ActorsMovies> ActorsMovies { get; set; } = new List<ActorsMovies>();
    }
}