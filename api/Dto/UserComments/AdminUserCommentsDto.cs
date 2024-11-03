using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.UserComments
{
    public class AdminUserCommentsDto
    {
        public int CommnetId { get; set; }
        public string AppUserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int MoviesId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public decimal Score { get; set; }
    }
}