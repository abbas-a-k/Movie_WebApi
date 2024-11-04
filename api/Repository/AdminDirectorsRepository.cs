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
            var directorModel = await _context.Directors
            .Include(element => element.Movies)
            .ThenInclude(element => element.Comments)
            .ThenInclude(element => element.ReplyComments)
            .Include(element => element.Movies)
            .ThenInclude(element => element.ActorsMovies)
            .FirstOrDefaultAsync(element => element.Id == directorId);

            foreach (var movie in directorModel.Movies)
            {
                foreach (var comment in movie.Comments)
                {
                    _context.Comments.Remove(comment);
                } 
                  
                foreach (var actorMovie in movie.ActorsMovies)
                {
                    _context.ActorsMovies.Remove(actorMovie);
                }
            }

            _context.Movies.RemoveRange(directorModel.Movies);  
            _context.Directors.Remove(directorModel);   

            await _context.SaveChangesAsync(); 

            return directorModel;
        }

        public async Task<bool> DirectorsExists(int directorId)
        {
            return await _context.Directors.AnyAsync(element => element.Id == directorId);
        }
    }
}
