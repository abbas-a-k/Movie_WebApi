using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helper;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/actors")]
    [ApiController]
    [Authorize]
    public class UserActorsController : ControllerBase
    {
        private readonly IUserActorsRepository _actorsRepo;
        public UserActorsController(IUserActorsRepository actorsRepo)
        {
            _actorsRepo = actorsRepo;
        }

        [HttpGet]
        [Authorize]
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

        [HttpGet("{actorId:int}")]
        [Authorize]
        public async Task<IActionResult> GetByIdForUser([FromRoute] int actorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var actor = await _actorsRepo.GetByIdForUser(actorId);
            if(actor == null)
            {
                return NotFound();
            }

            return Ok(actor.ToUserActorsDto());
        }
    }
}