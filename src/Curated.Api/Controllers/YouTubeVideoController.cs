using System.Net;
using System.Threading.Tasks;
using Curated.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Curated.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouTubeVideoController
    {
        private readonly IMediator _mediator;

        public YouTubeVideoController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{youTubeVideoId}", Name = "GetYouTubeVideoByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideoById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideoById.Response>> GetById([FromRoute]GetYouTubeVideoById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.YouTubeVideo == null)
            {
                return new NotFoundObjectResult(request.YouTubeVideoId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetYouTubeVideosRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideos.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideos.Response>> Get()
            => await _mediator.Send(new GetYouTubeVideos.Request());
        
        [HttpPost(Name = "CreateYouTubeVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateYouTubeVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateYouTubeVideo.Response>> Create([FromBody]CreateYouTubeVideo.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetYouTubeVideosPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetYouTubeVideosPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetYouTubeVideosPage.Response>> Page([FromRoute]GetYouTubeVideosPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateYouTubeVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateYouTubeVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateYouTubeVideo.Response>> Update([FromRoute]UpdateYouTubeVideo.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{youTubeVideoId}", Name = "RemoveYouTubeVideoRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveYouTubeVideo.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveYouTubeVideo.Response>> Remove([FromRoute]RemoveYouTubeVideo.Request request)
            => await _mediator.Send(request);
        
    }
}
