using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Directors> Directors { set; get; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Actors> Actors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movies>()
            .HasMany(e => e.Actors)
            .WithMany(e => e.Movies);
        }
    }
}