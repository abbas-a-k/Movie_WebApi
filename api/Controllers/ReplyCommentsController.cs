using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.ReplyComments;
using api.Interfaces;
using api.Mapper;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/replycomments")]
    [Authorize(Roles = "Admin")]
    public class ReplyCommentsController : ControllerBase
    {
        private readonly IReplyCommentsRepository _replyCommentsRepo;
        private readonly AdminCommentsRepository _adminCommentsRepo;
        public ReplyCommentsController(IReplyCommentsRepository replyCommentsRepo, AdminCommentsRepository adminCommentsRepo)
        {
            _replyCommentsRepo = replyCommentsRepo;
            _adminCommentsRepo = adminCommentsRepo;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllReplyCommentsForAdmin()
        {
            var replyComments = await _replyCommentsRepo.GetAllReplyCommentsForAdmin();
            var replyCommentsDto = replyComments.Select(element => element.ToAdminReplyCommentsDto());

            return Ok(replyCommentsDto);
        }

        [HttpGet("replycommetsid/{replyCommentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByReplyCommentsIdForAdmin([FromRoute] int replyCommentsId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _replyCommentsRepo.ReplyCommentsExistsForAdmin(replyCommentsId))
            {
                return NotFound("Replycomment not Found");
            }

            var replyComment = await _replyCommentsRepo.GetByReplyCommentsIdForAdmin(replyCommentsId);
            var replyCommentDto = replyComment.ToAdminReplyCommentsDto();

            return Ok(replyCommentDto);
        }
        
        [HttpGet("commentsId/{commentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByCommentsIdForAdmin([FromRoute] int commentsId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminCommentsRepo.CommentsExistsForAdmin(commentsId))
            {
                return NotFound("Usercomment Not Found");
            }

            var replyComment = await _replyCommentsRepo.GetByCommentsIdForAdmin(commentsId);
            var replyCommentDto = replyComment.ToAdminReplyCommentsDto();

            return Ok(replyCommentDto);
        }

        [HttpPost("{commentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateReplyCommentForAdmin([FromRoute] int commentsId, [FromBody] CreateReplyCommentsDto replyCommentsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _adminCommentsRepo.CommentsExistsForAdmin(commentsId))
            {
                return NotFound("Usercomment Not Found");
            }

            if(await _adminCommentsRepo.CommentsHasReplyCommentsForAdmin(commentsId))
            {
                return BadRequest("The comment has a replycomment");
            }

            var replyCommentModel = replyCommentsDto.ToReplyCommentsFromCreate(commentsId);
            var create = await _replyCommentsRepo.CreateReplyCommentsForAdmin(replyCommentModel);

            return Created();
        }

        [HttpPut("{replyCommentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateReplyCommentForAdmin([FromRoute] int replyCommentsId, [FromBody] UpdateReplyCommentsDto replyCommentsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _replyCommentsRepo.ReplyCommentsExistsForAdmin(replyCommentsId))
            {
                return NotFound("Replycomment not Found");
            }

            var replyCommentsModle = await _replyCommentsRepo.UpdateReplyCommentsForAdmin(replyCommentsId, replyCommentsDto);

            return Created();
        }

        [HttpDelete("{replyCommentsId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReplyCommentsForAdmin([FromRoute] int replyCommentsId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            if(!await _replyCommentsRepo.ReplyCommentsExistsForAdmin(replyCommentsId))
            {
                return NotFound("Replycomment not Found");
            }

            await _replyCommentsRepo.DeleteReplyCommentsForAdmin(replyCommentsId);

            return NoContent();
        }

    }
}