using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.AdminMovies
{
    public class CreateNewMovieDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "ImageUrl most be 5 characters")]
        [MaxLength(2048,ErrorMessage = "ImageUrl cannot be over 280 characters")]
        [Url(ErrorMessage = "ImageUrl is not valid")]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage = "Name most be 5 characters")]
        [MaxLength(20,ErrorMessage = "Name cannot be over 20 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage = "Genre most be 5 characters")]
        [MaxLength(20,ErrorMessage = "Genre cannot be over 20 characters")]
        public string Genre { get; set; } = string.Empty;
        [Required]
        [MinLength(5,ErrorMessage = "Country most be 5 characters")]
        [MaxLength(20,ErrorMessage = "Country cannot be over 20 characters")]
        public string Country { get; set;} = string.Empty;
        [Required]
        public DateTime? ReleasedIn { get; set; }
        [Required]
        [Range(0.1,9.9)]
        public decimal IMDB { get; set; }
        [Required]
        [MinLength(2,ErrorMessage = "About most be 5 characters")]
        [MaxLength(280,ErrorMessage = "About cannot be over 280 characters")]
        public string About { get; set; } = string.Empty;
        [Required]
        public int DirectorId { get; set; }
    }
}