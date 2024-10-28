using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Directors> Directors { set; get; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<ActorsMovies> ActorsMovies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movies>()
            .HasMany(e => e.Actors)
            .WithMany(e => e.Movies);


            //jWT 
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
            //JWT end 

            
        }
    }
}