using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helper;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class UserActorsController : ControllerBase
    {
        private readonly IUserActorsRepository _actorsRepo;
        public UserActorsController(IUserActorsRepository actorsRepo)
        {
            _actorsRepo = actorsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForUser([FromQuery] UserActorsQueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            
            var actors = await _actorsRepo.GetAllAsyncForUser(query);
            var actorsDto = actors.Select(element => element.ToUserActorsDto());
            
            return Ok(actorsDto);
        }
    }
}