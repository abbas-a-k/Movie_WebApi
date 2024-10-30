using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.ReplyComments;

namespace api.Dto
{
    public class UserCommentsDto
    {
        public int CommnetId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public UserCommentsReplyCommentsDto ReplyComments { get; set; } = new UserCommentsReplyCommentsDto();
    }
}