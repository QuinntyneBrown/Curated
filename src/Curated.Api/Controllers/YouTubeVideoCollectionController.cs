using System.Net;
using System.Threading.Tasks;
using Curated.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curated.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouTubeVideoCollectionController
    {
        private readonly IMediator _mediator;

        public YouTubeVideoCollectionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{youTubeVideoCollectionId}", Name = "GetYouTubeVideoCollectionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoCollectionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoCollectionById.Response>> GetById([FromRoute]GetYouTubeVideoCollectionById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.YouTubeVideoCollection == null)
            {
                return new NotFoundObjectResult(request.YouTubeVideoCollectionId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetYouTubeVideoCollectionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoCollections.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoCollections.Response>> Get()
            => await _mediator.Send(new GetYouTubeVideoCollections.Request());
        
        [HttpPost(Name = "CreateYouTubeVideoCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateYouTubeVideoCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateYouTubeVideoCollection.Response>> Create([FromBody]CreateYouTubeVideoCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetYouTubeVideoCollectionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoCollectionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoCollectionsPage.Response>> Page([FromRoute]GetYouTubeVideoCollectionsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateYouTubeVideoCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateYouTubeVideoCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateYouTubeVideoCollection.Response>> Update([FromRoute]UpdateYouTubeVideoCollection.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{youTubeVideoCollectionId}", Name = "RemoveYouTubeVideoCollectionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveYouTubeVideoCollection.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveYouTubeVideoCollection.Response>> Remove([FromRoute]RemoveYouTubeVideoCollection.Request request)
            => await _mediator.Send(request);
        
    }
}
