using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Curated.Api.Models;
using Curated.Api.Core;
using Curated.Api.Interfaces;

namespace Curated.Api.Features
{
    public class RemoveYouTubeVideo
    {
        public class Request: IRequest<Response>
        {
            public Guid YouTubeVideoId { get; set; }
        }

        public class Response: ResponseBase
        {
            public YouTubeVideoDto YouTubeVideo { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var youTubeVideo = await _context.YouTubeVideos.SingleAsync(x => x.YouTubeVideoId == request.YouTubeVideoId);
                
                _context.YouTubeVideos.Remove(youTubeVideo);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideo = youTubeVideo.ToDto()
                };
            }
            
        }
    }
}
