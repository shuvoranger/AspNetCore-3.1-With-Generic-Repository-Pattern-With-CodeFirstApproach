using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvShowWebApp.Models;

namespace TvShowWebApp.Data
{
    public class TvShowWebAppContext : DbContext
    {
        public TvShowWebAppContext (DbContextOptions<TvShowWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<TvShowWebApp.Models.TvShow> TvShow { get; set; }
    }
}
