using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Repository
{
    public class AdminActorsRepository : IAdminActorsRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminActorsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Actors> CreateActorsForAdmin(Actors actorModel)
        {
            await _context.Actors.AddAsync(actorModel);
            await _context.SaveChangesAsync();
            return actorModel;
        }

        public async Task<bool> ActorExists(int actorId)
        {
            return await _context.Actors.AnyAsync(element => element.Id == actorId);
        }

        public async Task<List<Actors>> AddActorToMovieForAdmin(int actorId, int movieId)
        {
            var movieModel = await _context.Movies.Include(element => element.Actors).FirstOrDefaultAsync(element => element.Id == movieId);
            var actorModel = await _context.Actors.Where(element => element.Id == actorId).ToListAsync();
            movieModel.Actors = actorModel;

            await _context.SaveChangesAsync();

            return actorModel;
        }

        public async Task<Actors> DeleteActorForAdmin(int actorid)
        {
            var actorModel = await _context.Actors.FirstOrDefaultAsync(element => element.Id == actorid);

            _context.Actors.Remove(actorModel);
            await _context.SaveChangesAsync();

            return actorModel;
        }
    }
}