using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AdminCommentsRepository : IAdminCommentsRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminCommentsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetAllCommentsForAdmin()
        {
            var commentsModel = await _context.Comments
            .Include(element => element.AppUser)
            .Include(element => element.Movies)
            .Include(element => element.ReplyComments)
            .ToListAsync();

            return commentsModel;
        }

        public async Task<Comments> GetCommentsByIdForAdmin(int commentsId)
        {
            var commentsModel = await _context.Comments
            .Include(element => element.AppUser)
            .Include(element => element.Movies)
            .Include(element => element.ReplyComments)
            .FirstOrDefaultAsync(element => element.Id == commentsId);

            return commentsModel;
        }

        public async Task<bool> CommentsExistsForAdmin(int commentsId)
        {
            return await _context.Comments.AnyAsync(element => element.Id == commentsId);
        }

        public async Task<bool> CommentsHasReplyCommentsForAdmin(int commentsId)
        {
            return await _context.Comments.AnyAsync(element => element.Id == commentsId && element.ReplyComments != null);
        }

        public async Task<List<Comments>> GetCommentsByMoviesIdForAdmin(int moviesId)
        {
            var commentsModel = await _context.Comments
            .Include(element => element.AppUser)
            .Include(element => element.Movies)
            .Include(element => element.ReplyComments)
            .Where(element => element.MoviesId == moviesId).ToListAsync();

            return commentsModel;
        }

        public async Task<Comments> DeleteCommentsForAdmin(int commentsId)
        {
            var commentsModel = await _context.Comments
            .Include(element => element.ReplyComments)
            .FirstOrDefaultAsync(element => element.Id == commentsId);

            _context.Comments.Remove(commentsModel);
            await _context.SaveChangesAsync();

            return commentsModel;
        }
    }
}