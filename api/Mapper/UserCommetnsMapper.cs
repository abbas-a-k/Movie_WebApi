using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Dto.UserComments;
using api.Models;

namespace api.Mapper
{
    public static class UserCommetnsMapper
    {
        public static UserCommentsDto ToUserCommentsDto(this Comments commentsModel)
        {
            return new UserCommentsDto
            {
                CommnetId = commentsModel.Id,
                UserName = commentsModel.AppUser.UserName,
                MovieId = commentsModel.Movies.Id,
                MovieName = commentsModel.Movies.Name,
                Content = commentsModel.Content,
                Score = commentsModel.Score,
                ReplyComments = commentsModel.ReplyComments.ToUserCommentsReplyCommentsDto()
            };
        }
        
        public static UserMoviesComentsDto ToUserMoviesComentsDto(this Comments commentsModel)
        {
            return new UserMoviesComentsDto
            {
                UserName = commentsModel.AppUser.UserName,
                MovieId = commentsModel.Movies.Id,
                MovieName = commentsModel.Movies.Name,
                Content = commentsModel.Content,
                Score = commentsModel.Score,
                ReplyComments = commentsModel.ReplyComments.ToUserCommentsReplyCommentsDto()   
            };
        }

        public static Comments ToUserCommentsFromCreate (this CreateUserCommentDto commentDto , Movies moviesModel , AppUser appUser)
        {
            return new Comments
            {
                AppUserId = appUser.Id,
                MoviesId = moviesModel.Id,
                Content = commentDto.content,
                Score = commentDto.Score,
                Movies = moviesModel
            };
        }

        public static Comments ToUserCommentsFromUpdate (this UpdateUserCommentsDto commentsDto)
        {
            return new Comments
            {
                Content = commentsDto.content,
                Score = commentsDto.Score
            };
        }
    }
}