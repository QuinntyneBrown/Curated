using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Curated.Api.Core;
using Curated.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curated.Api.Features
{
    public class GetYouTubeVideoItems
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<YouTubeVideoItemDto> YouTubeVideoItems { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    YouTubeVideoItems = await _context.YouTubeVideoItems.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
