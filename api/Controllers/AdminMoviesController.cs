using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminMovies;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/adminmovies")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminMoviesController : ControllerBase
    {
        private readonly IAdminMoviesRepository _adminMoviesRepo;
        private readonly IAdminDirectorsRepository _adminDirectorRepo;
        public AdminMoviesController(IAdminMoviesRepository adminMoviesRepo, IAdminDirectorsRepository adminDirectorRepo) 
        {
            _adminMoviesRepo = adminMoviesRepo;
            _adminDirectorRepo = adminDirectorRepo;
        }

        [HttpPost("createmovie")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMoviesForAdmin([FromBody] CreateNewMovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminDirectorRepo.DirectorsExists(movieDto.DirectorId))
            {
                return NotFound("Director Not Found");
            }

            var movieModel = movieDto.ToMoviesFromCreteNewMovieDto();
            var create = await _adminMoviesRepo.CreateMoviesForAdmin(movieModel);

            return Created();
        }

        [HttpDelete("{movieId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMoviesForAdmin([FromRoute]int movieId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminMoviesRepo.MoviesExists(movieId))
            {
                return NotFound("Movie not found");
            }
            
            var movie = await _adminMoviesRepo.DeleteMoviesForAdmin(movieId);
            return NoContent();
        }
    }
}