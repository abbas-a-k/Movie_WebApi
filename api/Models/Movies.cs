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
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "decimal(1,1)")]
        public decimal IMDB { get; set; }
        public int? DirectorsId { set; get; }
        public Directors? Directors { get; set;}
        // Not stored in the database
        //public decimal InternalScore { get; set; }
        //public List<Comments> Comments { get; set; }
        //public List<Actors> Actors { get; set; }   
    }
}