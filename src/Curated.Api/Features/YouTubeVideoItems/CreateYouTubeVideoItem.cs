using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Models;
using Curated.Api.Core;
using Curated.Api.Interfaces;

namespace Curated.Api.Features
{
    public class CreateYouTubeVideoItem
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.YouTubeVideoItem).NotNull();
                RuleFor(request => request.YouTubeVideoItem).SetValidator(new YouTubeVideoItemValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public YouTubeVideoItemDto YouTubeVideoItem { get; set; }
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
                var youTubeVideoItem = new YouTubeVideoItem();
                
                _context.YouTubeVideoItems.Add(youTubeVideoItem);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideoItem = youTubeVideoItem.ToDto()
                };
            }
            
        }
    }
}
