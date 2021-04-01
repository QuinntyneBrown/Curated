using System.Net;
using System.Threading.Tasks;
using Curated.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curated.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouTubeVideoItemController
    {
        private readonly IMediator _mediator;

        public YouTubeVideoItemController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{youTubeVideoItemId}", Name = "GetYouTubeVideoItemByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoItemById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoItemById.Response>> GetById([FromRoute]GetYouTubeVideoItemById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.YouTubeVideoItem == null)
            {
                return new NotFoundObjectResult(request.YouTubeVideoItemId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetYouTubeVideoItemsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoItems.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoItems.Response>> Get()
            => await _mediator.Send(new GetYouTubeVideoItems.Request());
        
        [HttpPost(Name = "CreateYouTubeVideoItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateYouTubeVideoItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateYouTubeVideoItem.Response>> Create([FromBody]CreateYouTubeVideoItem.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetYouTubeVideoItemsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoItemsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoItemsPage.Response>> Page([FromRoute]GetYouTubeVideoItemsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateYouTubeVideoItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateYouTubeVideoItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateYouTubeVideoItem.Response>> Update([FromRoute]UpdateYouTubeVideoItem.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{youTubeVideoItemId}", Name = "RemoveYouTubeVideoItemRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveYouTubeVideoItem.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveYouTubeVideoItem.Response>> Remove([FromRoute]RemoveYouTubeVideoItem.Request request)
            => await _mediator.Send(request);
        
    }
}
