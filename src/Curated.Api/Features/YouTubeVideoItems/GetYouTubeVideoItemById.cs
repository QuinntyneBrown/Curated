using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Core;
using Curated.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curated.Api.Features
{
    public class GetYouTubeVideoItemById
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
                return new () {
                    YouTubeVideoItem = (await _context.YouTubeVideoItems.SingleOrDefaultAsync()).ToDto()
                };
            }
            
        }
    }
}
