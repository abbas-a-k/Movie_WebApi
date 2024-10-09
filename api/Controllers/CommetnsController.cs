using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommetnsController : ControllerBase
    {
        private readonly ICommetnsRepository _commentsRepo;
        public CommetnsController(ICommetnsRepository commentsRepo)
        {
            _commentsRepo = commentsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentsForUser()
        {
            var comments = await _commentsRepo.GetAllasyncForUser();
            var commentsDto = comments.Select(element => element.ToCommentsDto());
            return Ok(commentsDto);
        }
    }
}