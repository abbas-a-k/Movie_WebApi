using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.UserComments
{
    public class CreateUserCommentDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "content most be 5 characters")]
        [MaxLength(280,ErrorMessage = "content cannot be over 280 characters")]
        public string content { get; set; } = string.Empty;
        [Required]
        [Range(0.1,9.9)]
        public decimal  Score { get; set; }
    }
}