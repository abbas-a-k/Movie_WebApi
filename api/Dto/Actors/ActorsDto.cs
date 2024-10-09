using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Actors
{
    public class ActorsDto
    {
        public string ImageUrl { set; get; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string DateOfBirth { get; set; } = string.Empty;
        public bool Alive { get; set; } = true;
        public string BirthPlace { get; set; } = string.Empty;
        public string About { get; set;} = string.Empty;
    }
}