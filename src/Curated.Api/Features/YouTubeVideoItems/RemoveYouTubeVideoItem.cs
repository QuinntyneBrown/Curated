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
    public class RemoveYouTubeVideoItem
    {
        public class Request: IRequest<Response>
        {
            public Guid YouTubeVideoItemId { get; set; }
        }

        public class Response: ResponseBase
        {
            public YouTubeVideoItemDto YouTubeVideoItem { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var youTubeVideoItem = await _context.YouTubeVideoItems.SingleAsync(x => x.YouTubeVideoItemId == request.YouTubeVideoItemId);
                
                _context.YouTubeVideoItems.Remove(youTubeVideoItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideoItem = youTubeVideoItem.ToDto()
                };
            }
            
        }
    }
}
