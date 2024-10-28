using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.AdminActors
{
    public class CreateNewActorsDto
    {
        [Required]
        [MinLength(2,ErrorMessage = "ImageUrl most be 5 characters")]
        [MaxLength(2048,ErrorMessage = "ImageUrl cannot be over 280 characters")]
        [Url(ErrorMessage = "ImageUrl is not valid")]
        public string ImageUrl { set; get; } = string.Empty;
        [Required]
        [MinLength(2,ErrorMessage = "Name most be 2 characters")]
        [MaxLength(20,ErrorMessage = "Name cannot be over 20 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(15,100)]
        public int Age { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Alive { get; set; } = true;
        [Required]
        [MinLength(2,ErrorMessage = "BirthPlace most be 5 characters")]
        [MaxLength(20,ErrorMessage = "BirthPlace cannot be over 20 characters")]
        public string BirthPlace { get; set; } = string.Empty;
        [Required]
        [MinLength(2,ErrorMessage = "About most be 5 characters")]
        [MaxLength(280,ErrorMessage = "About cannot be over 280 characters")]
        public string About { get; set;} = string.Empty;
    }
}