using System;

namespace Curated.Api.Models
{
    public class YouTubeVideoCollection: Collection<YouTubeVideo>
    {
        public Guid YouTubeVideoCollectionId { get; set; }
        
    }
}
