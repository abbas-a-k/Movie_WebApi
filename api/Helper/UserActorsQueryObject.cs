using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helper
{
    public class UserActorsQueryObject
    {
        public string? Name { get; set; }
        public string? BirthPlace { get; set; }
        public string? SortBy { get; set; }
        public bool IsDecsending { get; set; } = false;
    }
}