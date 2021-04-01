using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Models;
using Curated.Api.Core;
using Curated.Api.Interfaces;

namespace Curated.Api.Features
{
    public class CreateYouTubeVideoCollection
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.YouTubeVideoCollection).NotNull();
                RuleFor(request => request.YouTubeVideoCollection).SetValidator(new YouTubeVideoCollectionValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public YouTubeVideoCollectionDto YouTubeVideoCollection { get; set; }
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
                var youTubeVideoCollection = new YouTubeVideoCollection();
                
                _context.YouTubeVideoCollections.Add(youTubeVideoCollection);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideoCollection = youTubeVideoCollection.ToDto()
                };
            }
            
        }
    }
}
