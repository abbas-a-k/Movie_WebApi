using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DirectorsRepository : IDirectorsRepository
    {
        private readonly ApplicationDBContext _context;
        public DirectorsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Directors>> GetAllForUserAsync()
        {
            return await _context.Directors.ToListAsync();
        }
    }
}