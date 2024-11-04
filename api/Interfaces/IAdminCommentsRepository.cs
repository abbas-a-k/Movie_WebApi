using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdminCommentsRepository
    {
        Task<List<Comments>> GetAllCommentsForAdmin();
        Task<Comments> GetCommentsByIdForAdmin(int commentsId);
        Task<List<Comments>> GetCommentsByMoviesIdForAdmin(int moviesId);
        Task<Comments> DeleteCommentsForAdmin(int commentsId);
        Task<bool> CommentsExistsForAdmin(int commentsId);
        Task<bool> CommentsHasReplyCommentsForAdmin(int commentsId);
    }
}