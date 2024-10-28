using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mapper;
using api.Helper;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class UserDirectorsController : ControllerBase
    {
        private readonly IUserDirectorsRepository _directorRepo;
        public UserDirectorsController(IUserDirectorsRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllForUser([FromQuery] UserDirectorsQueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            
            var directors = await _directorRepo.GetAllForUserAsync(query);
            var directorsDto = directors.Select(element => element.ToUserDirectorsDto());
            
            return Ok(directorsDto);
        }

        [HttpGet("{directorId:int}")]
        [Authorize]
        public async Task<IActionResult> GetByIdforUser([FromRoute] int directorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var director = await _directorRepo.GetByIdAsyncForUser(directorId);
            if(director == null)
            {
                return NotFound();
            }

            return Ok(director.ToUserDirectorsDto());
        }
    }
}   