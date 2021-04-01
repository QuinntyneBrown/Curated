using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Core;
using Curated.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curated.Api.Features
{
    public class UpdateYouTubeVideo
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.YouTubeVideo).NotNull();
                RuleFor(request => request.YouTubeVideo).SetValidator(new YouTubeVideoValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public YouTubeVideoDto YouTubeVideo { get; set; }
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
                var youTubeVideo = await _context.YouTubeVideos.SingleAsync(x => x.YouTubeVideoId == request.YouTubeVideo.YouTubeVideoId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    YouTubeVideo = youTubeVideo.ToDto()
                };
            }
            
        }
    }
}
