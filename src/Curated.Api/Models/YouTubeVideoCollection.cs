using System;

namespace Curated.Api.Models
{
    public class YouTubeVideoCollection: Collection<YouTubeVideoItem>
    {
        public Guid YouTubeVideoCollectionId { get; set; }
        
    }
}
