using System;

namespace Curated.Api.Models
{
    public class YouTubeVideoItem : CollectionItem
    {
        public Guid YouTubeVideoItemId { get; set; }
        public string YouTubeVideoId { get; private set; }
    }
}
