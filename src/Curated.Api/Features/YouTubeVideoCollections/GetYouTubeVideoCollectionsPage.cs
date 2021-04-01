using Curated.Api.Core;
using Curated.Api.Extensions;
using Curated.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Curated.Api.Features
{
    public class GetYouTubeVideoCollectionsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<YouTubeVideoCollectionDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from youTubeVideoCollection in _context.YouTubeVideoCollections
                    select youTubeVideoCollection;
                
                var length = await _context.YouTubeVideoCollections.CountAsync();
                
                var youTubeVideoCollections = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = youTubeVideoCollections
                };
            }
            
        }
    }
}
