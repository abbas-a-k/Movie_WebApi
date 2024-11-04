using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.AdminComments;
using api.Models;

namespace api.Mapper
{
    public static class AdminCommentsMapper
    {
        public static AdminCommentsDto ToAdminCommentsDto(this Comments commentsModel)
        {
            return new AdminCommentsDto
            {
                CommnetId = commentsModel.Id,
                UserName = commentsModel.AppUser.UserName,
                MovieId = commentsModel.Movies.Id,
                MovieName = commentsModel.Movies.Name,
                Content = commentsModel.Content,
                Score = commentsModel.Score,
                ReplyComments = commentsModel.ReplyComments.ToAdminCommentsReplyCommentsDto() 
            };
        }
    }
}