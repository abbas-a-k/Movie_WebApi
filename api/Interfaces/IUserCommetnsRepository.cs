using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserCommetnsRepository
    {
        Task<List<Comments>> GetAllasyncForUser(AppUser userName);
        Task<Comments> CreateCommentsAsyncForUser(Comments commentModel);
    }
}