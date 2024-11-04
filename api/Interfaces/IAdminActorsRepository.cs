using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdminActorsRepository 
    {
        Task<Actors> CreateActorsForAdmin(Actors actorModel);
        Task<ActorsMovies> AddActorToMovieForAdmin(int actorid,int movieId);
        Task<Actors> DeleteActorForAdmin(int actorid);
        Task<ActorsMovies> DeleteActorMovieForAdmin(int actorid,int movieId);
        Task<bool> ActorExists(int actorId);
        Task<bool> ActorsMoviesExists(int actorid,int movieId);
    }
}