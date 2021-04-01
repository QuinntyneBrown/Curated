using System;

namespace Curated.Api.Features
{
    public class YouTubeVideoCollectionDto: CollectionDto<YouTubeVideoItemDto>
    {
        public Guid YouTubeVideoCollectionId { get; set; }
    }
}
