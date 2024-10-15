using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Helper;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        private readonly IUserMoviesRepository _moviesRepo;
        public UserMoviesController(IUserMoviesRepository moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllForUser([FromQuery] UserMoviesQueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var userMovies = await _moviesRepo.GetAllAsyncForUser(query);
            var UserMoviesDto = userMovies.Select(element => element.ToUserMoviesDto());

            return Ok(UserMoviesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdForUser([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var userMovies = await _moviesRepo.GetByIdAsyncForUser(id);
            
            if(userMovies==null){
                return NotFound();
            }

            return Ok(userMovies.ToUserMoviesDto());
        }
    }
}