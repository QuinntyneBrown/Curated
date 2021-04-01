using System;
using Curated.Api.Models;

namespace Curated.Api.Features
{
    public static class YouTubeVideoItemExtensions
    {
        public static YouTubeVideoItemDto ToDto(this YouTubeVideoItem youTubeVideoItem)
        {
                return new ()
                {
                    YouTubeVideoItemId = youTubeVideoItem.YouTubeVideoItemId
                };
        }
        
    }
}
