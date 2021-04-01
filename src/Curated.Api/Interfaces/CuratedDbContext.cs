using Curated.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Curated.Api.Interfaces
{
    public interface ICuratedDbContext
    {
        DbSet<YouTubeVideoCollection> YouTubeVideoCollections { get; }
        DbSet<YouTubeVideo> YouTubeVideos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
