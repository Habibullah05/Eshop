using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortApp.Models.Entities;

namespace UrlShortApp.Models.Repositories
{
    public class UrlContext:DbContext
    {
        public virtual DbSet<UrlShort> ShortUrls { get; set; }
        public UrlContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UrlShort>()
                .HasIndex(u => u.ShortURL)
                .IsUnique();
        }


    }
}
