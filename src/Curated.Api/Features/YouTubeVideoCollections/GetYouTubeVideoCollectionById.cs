using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Core;
using Curated.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curated.Api.Features
{
    public class GetYouTubeVideoCollectionById
    {
        public class Request: IRequest<Response>
        {
            public Guid YouTubeVideoCollectionId { get; set; }
        }

        public class Response: ResponseBase
        {
            public YouTubeVideoCollectionDto YouTubeVideoCollection { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    YouTubeVideoCollection = (await _context.YouTubeVideoCollections.SingleOrDefaultAsync()).ToDto()
                };
            }
            
        }
    }
}
