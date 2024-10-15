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
    public class UserMoviesRepository : IUserMoviesRepository
    {
        private readonly ApplicationDBContext _context;
        public UserMoviesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Movies>> GetAllAsyncForUser(UserMoviesQueryObject query)
        {
            var movies = _context.Movies.Include(element => element.Actors)
            .Include(element => element.Comments).Include(element => element.Directors).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                movies = movies.Where(element => element.Name.Contains(query.Name));
            }

            if(!string.IsNullOrWhiteSpace(query.Genre))
            {
                movies = movies.Where(element => element.Genre.Contains(query.Genre));
            }
            
            if(!string.IsNullOrWhiteSpace(query.Director))
            {
                movies = movies.Where(element => element.Directors.Name.Contains(query.Director));
            }

            if(!string.IsNullOrWhiteSpace(query.Actor))
            {
                movies = movies.Where(element => element.Actors.Select(x => x.Name).ToList().Contains(query.Actor));
            }

            if(!string.IsNullOrWhiteSpace(query.Country))
            {
                movies = movies.Where(element => element.Country.Contains(query.Country));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.Name) : movies.OrderBy(element => element.Name);
                }

                if(query.SortBy.Equals("Genre",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.Genre) : movies.OrderBy(element => element.Genre);
                }

                if(query.SortBy.Equals("Director",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.Directors) : movies.OrderBy(element => element.Directors);
                }

                if(query.SortBy.Equals("Country",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.Country) : movies.OrderBy(element => element.Country);
                }

                if(query.SortBy.Equals("IMDB",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.IMDB) : movies.OrderBy(element => element.IMDB);
                }
                
                if(query.SortBy.Equals("ReleasedIn",StringComparison.OrdinalIgnoreCase))
                {
                    movies = query.IsDecsending ? movies.OrderByDescending(element => element.ReleasedIn) : movies.OrderBy(element => element.ReleasedIn);
                }
            }

            return await movies.ToListAsync();

        }

        public async Task<Movies?> GetByIdAsyncForUser(int id)
        {
            return await _context.Movies.Include(element => element.Actors)
            .Include(element => element.Comments).Include(element => element.Directors)
            .FirstOrDefaultAsync(element => element.Id == id);
        }
    }
}