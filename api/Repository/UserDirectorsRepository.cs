using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Data;
using api.Helper;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserDirectorsRepository : IUserDirectorsRepository
    {
        private readonly ApplicationDBContext _context;
        public UserDirectorsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Directors>> GetAllForUserAsync(UserDirectorsQueryObject query)
        {
            var directors = _context.Directors.Include(element => element.Movies).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                directors = directors.Where(element => element.Name.Contains(query.Name));
            }

            if(!string.IsNullOrWhiteSpace(query.BirthPlace))
            {
                directors = directors.Where(element => element.BirthPlace.Contains(query.BirthPlace));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    directors = query.IsDecsending ? directors.OrderByDescending(element => element.Name) : directors.OrderBy(element => element.Name);
                }

                if(query.SortBy.Equals("Age",StringComparison.OrdinalIgnoreCase))
                {
                    directors = query.IsDecsending ? directors.OrderByDescending(element => element.Age) : directors.OrderBy(element => element.Age);
                }

                if(query.SortBy.Equals("DateOfBirth",StringComparison.OrdinalIgnoreCase))
                {
                    directors = query.IsDecsending ? directors.OrderByDescending(element => element.DateOfBirth) : directors.OrderBy(element => element.DateOfBirth);
                }

                if(query.SortBy.Equals("Alive",StringComparison.OrdinalIgnoreCase))
                {
                    directors = query.IsDecsending ? directors.OrderByDescending(element => element.Alive) : directors.OrderBy(element => element.Alive);
                }

                if(query.SortBy.Equals("BirthPlace",StringComparison.OrdinalIgnoreCase))
                {
                    directors = query.IsDecsending ? directors.OrderByDescending(element => element.BirthPlace) : directors.OrderBy(element => element.BirthPlace);
                }
            }

            return await directors.ToListAsync();
        }

        public async Task<Directors> GetByIdAsyncForUser(int directorId)
        {
            return await _context.Directors
            .Include(element => element.Movies)
            .FirstOrDefaultAsync(element => element.Id == directorId);
        }
    }
}