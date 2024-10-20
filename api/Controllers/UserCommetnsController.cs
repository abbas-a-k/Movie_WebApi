using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Dto.UserComments;
using api.Extensions;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    public class UserCommetnsController : ControllerBase
    {
        private readonly IUserCommetnsRepository _commentsRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserMoviesRepository _moviesRepo;
        public UserCommetnsController(IUserCommetnsRepository commentsRepo , UserManager<AppUser> userManager , IUserMoviesRepository moviesRepo)
        {
            _commentsRepo = commentsRepo;
            _userManager = userManager;
            _moviesRepo = moviesRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCommentsForUser()
        {
            var isInRole = User.IsInRole("Admin");
            if(isInRole)
            {
                return Forbid();
            }

            var userName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var comments = await _commentsRepo.GetAllasyncForUser(appUser);
            var commentDto = comments.Select(element => element.ToUserCommentsDto());
            return Ok(commentDto);
        }
        
        [HttpPost("{movieId:int}")]
        [Authorize]
        public async Task<IActionResult> CreateCommentForUser([FromRoute]int movieId , CreateUserCommentDto commentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var isInRole = User.IsInRole("Admin");
            if(isInRole)
            {
                return Forbid();
            }
            
            var moviesModel = await _moviesRepo.GetByIdAsyncForUser(movieId);
            if(moviesModel == null)
            {
                return BadRequest("movie does not exist.");
            }

            var userName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);

            var commentModel = commentDto.ToUserCommentsFromCreate(moviesModel,appUser);
            var create = await _commentsRepo.CreateCommentsAsyncForUser(commentModel);

            return Ok(create.ToUserCommentsDto());
        }

        [HttpPut("{commentId:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateCommnetForUser([FromRoute] int commentId,[FromBody] UpdateUserCommentsDto commentsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var isInRole = User.IsInRole("Admin");
            if(isInRole)
            {
                return Forbid();
            }
            
            var userName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);

            var comment = await _commentsRepo.UpdateUserCommentsAsyncForUser(commentId,commentsDto.ToUserCommentsFromUpdate(),appUser);
            if (comment == null)
            {
                return NotFound("Comment Not Found");
            }

            return Ok(comment.ToUserCommentsDto());

        }
        
        [HttpDelete("{commentId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCommentForUser([FromRoute] int commentId)
        {
            var isInRole = User.IsInRole("Admin");
            if(isInRole)
            {
                return Forbid();
            }

            var userName = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);

            var comment = await _commentsRepo.DeleteUserCommentsAsyncForUser(commentId,appUser);
            if (comment == null)
            {
                return NotFound("Comment Not Found");
            }

            return NoContent();
        }

    }
}