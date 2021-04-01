using Curated.Api.Models;
using Curated.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curated.Api.Data
{
    public class CuratedDbContext: DbContext, ICuratedDbContext
    {
        public DbSet<YouTubeVideoCollection> YouTubeVideoCollections { get; private set; }
        public DbSet<YouTubeVideoItem> YouTubeVideoItems { get; private set; }
        public CuratedDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CuratedDbContext).Assembly);
        }
        
    }
}
