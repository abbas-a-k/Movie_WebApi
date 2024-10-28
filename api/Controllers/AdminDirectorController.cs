using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminDirectors;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/admindirector")]
    [Authorize(Roles = "Admin")]
    public class AdminDirectorController : ControllerBase
    {
        private readonly IAdminDirectorsRepository _adminDirectorRepo;
        public AdminDirectorController(IAdminDirectorsRepository adminDirectorRepo)
        {
            _adminDirectorRepo = adminDirectorRepo;   
        }

        [HttpPost("createdirector")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDirectorForAdmin([FromBody] CreateNewDirectorDto directorDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var directorModel = directorDto.ToDirectorsFromCreatrNewDirectorDto();
            var create = await _adminDirectorRepo.CreateDirectorForAdmin(directorModel);

            return Created();
        }
        [HttpDelete("{directorId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDirectorForAdmin([FromRoute] int directorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminDirectorRepo.DirectorsExists(directorId))
            {
                return NotFound("Director not found");
            }

            var director = await _adminDirectorRepo.DeleteDirectorsForAdmin(directorId);
            return NoContent();
        }
    }
}