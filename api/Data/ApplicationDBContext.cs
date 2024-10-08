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
        public DbSet<MoviesActors> MoviesActors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<MoviesActors>(x => x.HasKey(p => new {p.MovieId,p.ActorId}));
            builder.Entity<MoviesActors>().HasOne(u => u.Movies).WithMany(u => u.MoviesActors)
            .HasForeignKey(p => p.MovieId);
            builder.Entity<MoviesActors>().HasOne(u => u.Actors).WithMany(u => u.MoviesActors)
            .HasForeignKey(p => p.ActorId);
        }
    }
}