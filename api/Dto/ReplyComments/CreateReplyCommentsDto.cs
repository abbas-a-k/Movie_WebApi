using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.ReplyComments
{
    public class CreateReplyCommentsDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "content most be 5 characters")]
        [MaxLength(280,ErrorMessage = "content cannot be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}