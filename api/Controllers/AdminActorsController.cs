using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminActors;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/adminactor")]
    [Authorize(Roles = "Admin")]
    public class AdminActorsController : ControllerBase
    {
        private readonly IAdminActorsRepository _adminActorsRepo;
        private readonly IAdminMoviesRepository _adminMoviesRepo;
        public AdminActorsController(IAdminActorsRepository adminActorsRepo , IAdminMoviesRepository adminMoviesRepo)
        {
            _adminActorsRepo = adminActorsRepo;
            _adminMoviesRepo = adminMoviesRepo;
        }

        [HttpPost("createactor")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateActorForAdmin([FromBody] CreateNewActorsDto actorDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var acotormodel = actorDto.ToActorsFromCreateNewActorsDto();
            var create = await _adminActorsRepo.CreateActorsForAdmin(acotormodel);

            return Created();
        }

        [HttpPost("addactormovie")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddActorToMovieForAdmin(int actorId, int movieId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminActorsRepo.ActorExists(actorId))
            {
                return NotFound("Actor not found");
            }

            if(!await _adminMoviesRepo.MoviesExists(movieId))
            {
                return NotFound("Movie not found");
            }

            if(await _adminActorsRepo.ActorsMoviesExists(actorId,movieId))
            {
                return BadRequest("There is an actor in the movie");
            }
            
            var actorModel = _adminActorsRepo.AddActorToMovieForAdmin(actorId,movieId);

            return Ok();
        }

        [HttpDelete("{actorId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteActorForAdmin([FromRoute] int actorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminActorsRepo.ActorExists(actorId))
            {
                return NotFound("Actor not found");
            }

            var actorModel = await _adminActorsRepo.DeleteActorForAdmin(actorId);

            return NoContent();
        }
        [HttpDelete("deleteactormovie")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteActorFromMovieForAdmin(int actorId, int movieId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminActorsRepo.ActorExists(actorId))
            {
                return NotFound("Actor not found");
            }

            if(!await _adminMoviesRepo.MoviesExists(movieId))
            {
                return NotFound("Movie not found");
            }

            if(!await _adminActorsRepo.ActorsMoviesExists(actorId,movieId))
            {
                return NotFound("There is not an actor in the movie");
            }

            var actorMovie = await _adminActorsRepo.DeleteActorMovieForAdmin(actorId,movieId);

            return NoContent();
        }
    }
}