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

        public async Task<ActorsMovies> AddActorToMovieForAdmin(int actorId, int movieId)
        {
            var actorsMoviesModel = new ActorsMovies 
            {
                ActorsId = actorId,
                MoviesId = movieId
            };

            await _context.ActorsMovies.AddAsync(actorsMoviesModel);
            await _context.SaveChangesAsync();

            return actorsMoviesModel;
        }

        public async Task<Actors> DeleteActorForAdmin(int actorid)
        {
            var actorModel = await _context.Actors.FirstOrDefaultAsync(element => element.Id == actorid);

            _context.Actors.Remove(actorModel);
            await _context.SaveChangesAsync();

            return actorModel;
        }

        public async Task<bool> ActorsMoviesExists(int actorid, int movieId)
        {
            return await _context.ActorsMovies.AnyAsync(element => element.ActorsId == actorid && element.MoviesId == movieId);
        }

        public async Task<ActorsMovies> DeleteActorMovieForAdmin(int actorid, int movieId)
        {
            var actorsMoviesModel = await _context.ActorsMovies
            .FirstOrDefaultAsync(element => element.ActorsId == actorid && element.MoviesId == movieId);

            _context.Remove(actorsMoviesModel);
            await _context.SaveChangesAsync();

            return actorsMoviesModel;
        }
    }
}