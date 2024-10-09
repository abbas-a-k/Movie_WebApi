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
    public class CommentsRepository : ICommetnsRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentsRepository(ApplicationDBContext contex)
        {
            _context = contex;
        }
        public async Task<List<Comments>> GetAllasyncForUser()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}