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
    public class GetYouTubeVideoCollections
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<YouTubeVideoCollectionDto> YouTubeVideoCollections { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    YouTubeVideoCollections = await _context.YouTubeVideoCollections.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
