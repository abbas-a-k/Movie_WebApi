using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdminMoviesRepository
    {
        Task<Movies> DeleteMoviesForAdmin(int movieId);
        Task<Movies> CreateMoviesForAdmin(Movies movieModel);
        Task<bool> MoviesExists(int movieId);
    }
}