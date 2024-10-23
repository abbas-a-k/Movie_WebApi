using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserActorsRepository : IUserActorsRepository
    {
        private readonly ApplicationDBContext _context;
        public UserActorsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Actors>> GetAllAsyncForUser(UserActorsQueryObject query)
        {
            var actor = _context.Actors.Include(element => element.Movies).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                actor = actor.Where(element => element.Name.Contains(query.Name));
            }

            if(!string.IsNullOrWhiteSpace(query.BirthPlace))
            {
                actor = actor.Where(element => element.BirthPlace.Contains(query.BirthPlace));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    actor = query.IsDecsending ? actor.OrderByDescending(element => element.Name) : actor.OrderBy(element => element.Name);
                }

                if(query.SortBy.Equals("Age",StringComparison.OrdinalIgnoreCase))
                {
                    actor = query.IsDecsending ? actor.OrderByDescending(element => element.Age) : actor.OrderBy(element => element.Age);
                }

                if(query.SortBy.Equals("DateOfBirth",StringComparison.OrdinalIgnoreCase))
                {
                    actor = query.IsDecsending ? actor.OrderByDescending(element => element.DateOfBirth) : actor.OrderBy(element => element.DateOfBirth);
                }

                if(query.SortBy.Equals("Alive",StringComparison.OrdinalIgnoreCase))
                {
                    actor = query.IsDecsending ? actor.OrderByDescending(element => element.Alive) : actor.OrderBy(element => element.Alive);
                }

                if(query.SortBy.Equals("BirthPlace",StringComparison.OrdinalIgnoreCase))
                {
                    actor = query.IsDecsending ? actor.OrderByDescending(element => element.BirthPlace) : actor.OrderBy(element => element.BirthPlace);
                }
            }

            return await actor.ToListAsync();
        }

        public Task<Actors> GetByIdForUser(int actorId)
        {
            return _context.Actors
            .Include(element => element.Movies)
            .FirstOrDefaultAsync(element => element.Id == actorId);
        }
    }
}