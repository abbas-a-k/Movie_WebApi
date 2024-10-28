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
    public class AdminDirectorsRepository : IAdminDirectorsRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminDirectorsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Directors> CreateDirectorForAdmin(Directors directorModel)
        {
            await _context.Directors.AddAsync(directorModel);
            await _context.SaveChangesAsync();
            return directorModel;
        }

        public async Task<Directors> DeleteDirectorsForAdmin(int directorId)
        {
            var directorsModel = await _context.Directors.Include(element => element.Movies).ThenInclude(element => element.Comments).ToListAsync();
            var director = directorsModel.FirstOrDefault(element => element.Id == directorId);
            var movies = director.Movies.ToList();
            
            _context.Movies.RemoveRange(movies);
            _context.Directors.Remove(director);

            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<bool> DirectorsExists(int directorId)
        {
            return await _context.Directors.AnyAsync(element => element.Id == directorId);
        }
    }
}