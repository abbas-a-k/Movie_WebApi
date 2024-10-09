using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;

namespace api.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsRepository _actorsRepo;
        public ActorsController(IActorsRepository actorsRepo)
        {
            _actorsRepo = actorsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForUser()
        {
            var actors = await _actorsRepo.GetAllAsyncForUser();
            var actorsDto = actors.Select(element => element.ToActorsDto());
            return Ok(actorsDto);
        }
    }
}