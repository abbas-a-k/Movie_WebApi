using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class CommentsDto
    {
        public string Content { get; set; } = string.Empty;
        public decimal Score { get; set; }
    }
}