using Microsoft.EntityFrameworkCore;
using MovieTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTime.Data
{
    public class MovieTimeContext : DbContext
    {
        public MovieTimeContext(DbContextOptions<MovieTimeContext> options) : base(options)
        {

        }
        public DbSet<Series> Series { get; set; }
        
        public DbSet<Peliculas> Peliculas { get; set; }

        public DbSet<Documentales> Documentales { get; set; }
    }
}
