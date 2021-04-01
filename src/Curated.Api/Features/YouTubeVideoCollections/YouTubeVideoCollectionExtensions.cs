using System;
using Curated.Api.Models;

namespace Curated.Api.Features
{
    public static class YouTubeVideoCollectionExtensions
    {
        public static YouTubeVideoCollectionDto ToDto(this YouTubeVideoCollection youTubeVideoCollection)
        {
                return new ()
                {
                    YouTubeVideoCollectionId = youTubeVideoCollection.YouTubeVideoCollectionId
                };
        }
        
    }
}
