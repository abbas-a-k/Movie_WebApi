using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AdminMoviesRepository : IAdminMoviesRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminMoviesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Movies> CreateMoviesForAdmin(Movies movieModel)
        {
            await _context.Movies.AddAsync(movieModel);
            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task<Movies> DeleteMoviesForAdmin(int movieId)
        {
            var moviesModel = await _context.Movies.Include(element => element.Comments).ToListAsync();
            var movie = moviesModel.FirstOrDefault(element => element.Id == movieId);

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<bool> MoviesExists(int movieId)
        {
            return await _context.Movies.AnyAsync(element => element.Id == movieId);
        }
    }
}