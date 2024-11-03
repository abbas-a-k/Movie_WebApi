using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Repository
{
    public class UserCommentsRepository : IUserCommetnsRepository
    {
        private readonly ApplicationDBContext _context;
        public UserCommentsRepository(ApplicationDBContext contex)
        {
            _context = contex;
        }

        public async Task<bool> CommentsExistsForAdmin(int commentsId)
        {
            return await _context.Comments.AnyAsync(element => element.Id == commentsId);
        }

        public async Task<bool> CommentsHasReplyCommentsForAdmin(int commentsId)
        {
            return await _context.Comments.AnyAsync(element => element.Id == commentsId && element.ReplyComments != null);
        }

        public async Task<Comments> CreateCommentsAsyncForUser(Comments commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comments?> DeleteUserCommentsAsyncForUser(int commentId, AppUser appUser)
        {
            var existingComment = await _context.Comments.Include(element => element.Movies).FirstOrDefaultAsync(element => element.Id == commentId && element.AppUserId == appUser.Id);

            if (existingComment == null)
            {
                return null;
            }

            _context.Comments.Remove(existingComment);
            await _context.SaveChangesAsync();
            
            return existingComment;
        }

        public async Task<List<Comments>> GetAllasyncForUser(AppUser user)
        {
            var comment = _context.Comments.Include(element => element.AppUser).Include(element => element.Movies).Include(element => element.ReplyComments).Where(element => element.AppUser.UserName == user.UserName);

            if(comment == null)
            {
                return null;
            }
            
            return await comment.ToListAsync();
        }

        public async Task<Comments> UpdateUserCommentsAsyncForUser(int commentId, Comments comment, AppUser appUser)
        {
            var existingComment = await _context.Comments.Include(element => element.Movies).Include(element => element.ReplyComments).FirstOrDefaultAsync(element => element.Id == commentId && element.AppUserId == appUser.Id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Content = comment.Content;
            existingComment.Score = comment.Score;

            await _context.SaveChangesAsync();

            return existingComment;
        }
    }
}