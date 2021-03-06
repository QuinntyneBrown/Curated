using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Curated.Api.Models;
using Curated.Api.Core;
using Curated.Api.Interfaces;

namespace Curated.Api.Features
{
    public class CreateDigitalAsset
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DigitalAsset).NotNull();
                RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Response: ResponseBase
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly ICuratedDbContext _context;
        
            public Handler(ICuratedDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var digitalAsset = new DigitalAsset();
                
                _context.DigitalAssets.Add(digitalAsset);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    DigitalAsset = digitalAsset.ToDto()
                };
            }
            
        }
    }
}
