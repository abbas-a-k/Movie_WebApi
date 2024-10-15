using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mapper;
using api.Helper;

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
        public async Task<IActionResult> GetAllForUser([FromQuery] UserDirectorsQueryObject query)
        {
            var directors = await _directorRepo.GetAllForUserAsync(query);
            var directorsDto = directors.Select(element => element.ToUserDirectorsDto());
            
            return Ok(directorsDto);
        }
    }
}