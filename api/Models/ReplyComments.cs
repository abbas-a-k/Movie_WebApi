using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ReplyComments
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public int CommentsId { get; set; }
        public Comments Comments { get; set; }

    }
}