using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(2,1)")]
        public decimal Score { get; set; } 
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? MoviesId { get; set; }
        public Movies? Movies { get; set; }
    }
}