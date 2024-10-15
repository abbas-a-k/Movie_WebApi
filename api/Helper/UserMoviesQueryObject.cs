using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helper
{
    public class UserMoviesQueryObject
    {
        public string? Name { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Actor { get; set; }
        public string? Country { get; set; }
        public string? SortBy { get; set; }
        public bool IsDecsending { get; set; } = false;
    }
}