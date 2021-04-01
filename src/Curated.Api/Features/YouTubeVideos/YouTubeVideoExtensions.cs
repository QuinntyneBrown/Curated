using System;
using Curated.Api.Models;

namespace Curated.Api.Features
{
    public static class YouTubeVideoExtensions
    {
        public static YouTubeVideoDto ToDto(this YouTubeVideo youTubeVideo)
        {
                return new ()
                {
                    YouTubeVideoId = youTubeVideo.YouTubeVideoId
                };
        }
        
    }
}
