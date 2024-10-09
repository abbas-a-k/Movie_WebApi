using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepo;
        public MoviesController(IMoviesRepository moviesRepo)
        {
            _moviesRepo = moviesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllForUser()
        {
            var movies = await _moviesRepo.GetAllAsyncForUser();
            var moviesDto = movies.Select(element => element.ToMovieDto());
            return Ok(moviesDto);
        }
    }
}