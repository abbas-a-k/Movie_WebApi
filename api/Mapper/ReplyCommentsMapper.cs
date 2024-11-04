using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminReplyComments;
using api.Dto.ReplyComments;
using api.Models;

namespace api.Mapper
{
    public static class ReplyCommentsMapper
    {
        public static UserCommentsReplyCommentsDto ToUserCommentsReplyCommentsDto(this ReplyComments replyCommentsModel)
        {
            return new UserCommentsReplyCommentsDto
            {
                Name = "Admin",
                Content = replyCommentsModel.Content
            };
        }

        public static AdminReplyCommentsDto ToAdminReplyCommentsDto(this ReplyComments replyCommentsModel)
        {
            return new AdminReplyCommentsDto
            {
                Id = replyCommentsModel.Id,
                Content = replyCommentsModel.Content,
                CreateOn = replyCommentsModel.CreateOn,
                UserComment = replyCommentsModel.Comments.ToAdminUserCommentsDto()
            };
        }

        public static ReplyComments ToReplyCommentsFromCreate(this CreateReplyCommentsDto replyCommentsDto , int commentsId)
        {
            return new ReplyComments
            {
                Content = replyCommentsDto.Content,
                CommentsId = commentsId
            };
        }

        public static AdminCommentsReplyCommentsDto ToAdminCommentsReplyCommentsDto(this ReplyComments replyCommentsModel)
        {
            return new AdminCommentsReplyCommentsDto
            {
                Id = replyCommentsModel.Id,
                Content = replyCommentsModel.Content,
                CreateOn = replyCommentsModel.CreateOn
            };
        }
    }
}