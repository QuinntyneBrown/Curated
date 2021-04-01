using System;

namespace Curated.Api.Features
{
    public class YouTubeVideoCollectionDto: CollectionDto<YouTubeVideoDto>
    {
        public Guid YouTubeVideoCollectionId { get; set; }
    }
}
