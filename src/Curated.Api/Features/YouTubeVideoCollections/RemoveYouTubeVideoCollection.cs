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
    public class RemoveYouTubeVideoCollection
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
                var youTubeVideoCollection = await _context.YouTubeVideoCollections.SingleAsync(x => x.YouTubeVideoCollectionId == request.YouTubeVideoCollectionId);
                
                _context.YouTubeVideoCollections.Remove(youTubeVideoCollection);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideoCollection = youTubeVideoCollection.ToDto()
                };
            }
            
        }
    }
}
