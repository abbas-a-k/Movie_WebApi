using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Mapper
{
    public static class CommetnsMapper
    {
        public static CommentsDto ToCommentsDto(this Comments commentsModel)
        {
            return new CommentsDto
            {
                Content = commentsModel.Content,
                Score = commentsModel.Score     
            };
        }
    }
}