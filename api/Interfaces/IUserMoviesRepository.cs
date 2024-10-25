using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IUserMoviesRepository
    {
        Task <List<Movies>> GetAllAsyncForUser(UserMoviesQueryObject query);
        Task <Movies?> GetByIdAsyncForUser(int id);
    }
}