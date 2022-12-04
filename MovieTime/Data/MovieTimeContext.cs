using Microsoft.EntityFrameworkCore;
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
    }
}
