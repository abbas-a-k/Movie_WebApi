using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.ReplyComments;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReplyCommentsRepository : IReplyCommentsRepository
    {
        private readonly ApplicationDBContext _context;
        public ReplyCommentsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReplyComments> CreateReplyCommentsForAdmin(ReplyComments replyCommentsModel)
        {
            await _context.ReplyComments.AddAsync(replyCommentsModel);
            await _context.SaveChangesAsync();
            return replyCommentsModel;
        }

        public async Task<ReplyComments> DeleteReplyCommentsForAdmin(int replyCommentsId)
        {
            var replyCommentsModel = await _context.ReplyComments.FirstOrDefaultAsync(element => element.Id == replyCommentsId);

            _context.Remove(replyCommentsModel);
            await _context.SaveChangesAsync();

            return replyCommentsModel;
        }

        public async Task<List<ReplyComments>> GetAllReplyCommentsForAdmin()
        {
            return await _context.ReplyComments
            .Include(element => element.Comments).ThenInclude(element => element.AppUser)
            .Include(element => element.Comments).ThenInclude(element => element.Movies)
            .ToListAsync();
        }

        public async Task<ReplyComments> GetByCommentsIdForAdmin(int commentsId)
        {
             return await _context.ReplyComments
            .Include(element => element.Comments).ThenInclude(element => element.AppUser)
            .Include(element => element.Comments).ThenInclude(element => element.Movies)
            .FirstOrDefaultAsync(element => element.Comments.Id == commentsId);
        }

        public async Task<ReplyComments> GetByReplyCommentsIdForAdmin(int replyCommentsId)
        {
            return await _context.ReplyComments
            .Include(element => element.Comments).ThenInclude(element => element.AppUser)
            .Include(element => element.Comments).ThenInclude(element => element.Movies)
            .FirstOrDefaultAsync(element => element.Id == replyCommentsId);
        }

        public async Task<bool> ReplyCommentsExistsForAdmin(int replyCommentsId)
        {
            return await _context.ReplyComments.AnyAsync(element => element.Id == replyCommentsId);
        }

        public async Task<ReplyComments> UpdateReplyCommentsForAdmin(int replyCommentsId, UpdateReplyCommentsDto replyCommentsDto)
        {
            var replyCommentsModel = await _context.ReplyComments.FirstOrDefaultAsync(element => element.Id == replyCommentsId);

            replyCommentsModel.Content = replyCommentsDto.Content;

            await _context.SaveChangesAsync();

            return replyCommentsModel;
        }
    }
}