using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.ReplyComments;
using api.Models;

namespace api.Interfaces
{
    public interface IReplyCommentsRepository
    {
        Task<List<ReplyComments>> GetAllReplyCommentsForAdmin();
        Task<ReplyComments> GetByReplyCommentsIdForAdmin(int replyCommentsId);
        Task<ReplyComments> GetByCommentsIdForAdmin(int commentsId);
        Task<ReplyComments> CreateReplyCommentsForAdmin(ReplyComments replyCommentsModel);
        Task<ReplyComments> UpdateReplyCommentsForAdmin(int replyCommentsId, UpdateReplyCommentsDto replyCommentsDto);
        Task<ReplyComments> DeleteReplyCommentsForAdmin(int replyCommentsId);
        Task<bool> ReplyCommentsExistsForAdmin(int replyCommentsId);
    }
}