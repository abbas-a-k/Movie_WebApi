using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.UserComments;
using api.Models;

namespace api.Dto.AdminReplyComments
{
    public class AdminReplyCommentsDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public AdminUserCommentsDto UserComment { get; set; } = new AdminUserCommentsDto();

    }
}