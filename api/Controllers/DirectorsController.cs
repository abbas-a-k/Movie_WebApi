using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mapper;

namespace api.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorsRepository _directorRepo;
        public DirectorsController(IDirectorsRepository directorRepo)
        {
            _directorRepo = directorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForUser()
        {
            var directors = await _directorRepo.GetAllForUserAsync();
            var directorsDto = directors.Select(element => element.ToDirectorsDto());
            return Ok(directorsDto);
        }
    }
}