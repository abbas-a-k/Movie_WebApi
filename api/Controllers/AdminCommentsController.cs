using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/admincomments")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentsController : ControllerBase
    {
        private readonly IAdminCommentsRepository _adminCommentsRepo;
        private readonly IAdminMoviesRepository _adminMoviesRepo;
        public AdminCommentsController(IAdminCommentsRepository adminCommentsRepository, IAdminMoviesRepository adminMoviesRepo)
        {
            _adminCommentsRepo = adminCommentsRepository;
            _adminMoviesRepo = adminMoviesRepo;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCommentsForAdmin()
        {
            var commentsModel = await _adminCommentsRepo.GetAllCommentsForAdmin();
            var commentsModelDto = commentsModel.Select(element => element.ToAdminCommentsDto());

            return Ok(commentsModelDto);
        }

        [HttpGet("commentsid/{commentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCommentsByIdForAdmin([FromRoute] int commentsId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            
            if(!await _adminCommentsRepo.CommentsExistsForAdmin(commentsId))
            {
                return NotFound("Comment Not Found");
            }

            var commentsModel = await _adminCommentsRepo.GetCommentsByIdForAdmin(commentsId);

            return Ok(commentsModel.ToAdminCommentsDto());
        }

        [HttpGet("moviesid/{moviesid:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCommentsByMoviesIdForAdmin([FromRoute] int moviesid)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminMoviesRepo.MoviesExists(moviesid))
            {
                return NotFound("Movie Not Found");
            }

            var commetnsModel = await _adminCommentsRepo.GetCommentsByMoviesIdForAdmin(moviesid);
            var commentsModelDto = commetnsModel.Select(element => element.ToAdminCommentsDto());

            return Ok(commentsModelDto);
        }

        [HttpDelete("{commentsid:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCommentsForAdmin([FromRoute] int commentsid)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            
            if(!await _adminCommentsRepo.CommentsExistsForAdmin(commentsid))
            {
                return NotFound("Comment Not Found");
            }

            var commentsModel = await _adminCommentsRepo.DeleteCommentsForAdmin(commentsid);

            return NoContent();
        }
    }
}