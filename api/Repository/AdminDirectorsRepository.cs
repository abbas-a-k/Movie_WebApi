using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
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

        public async Task<bool> DirectorsExists(int directorId)
        {
            return await _context.Directors.AnyAsync(element => element.Id == directorId);
        }
    }
}