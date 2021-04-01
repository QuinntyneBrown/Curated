using System;

namespace Curated.Api.Models
{
    public class YouTubeVideo
    {
        public Guid YouTubeVideoId { get; set; }
        public string PlatformId { get; private set; }
        public string Title { get; set; }
    }
}
