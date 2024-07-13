using System;
using AutoMapper;
using DnSocial.Api.Contracts.Posts.Requests;
using DnSocial.Api.Contracts.Posts.Responses;
using DnSocial.Api.Filters;
using DnSocial.Application.Posts.Commands;
using DnSocial.Application.Posts.Queries;
using MediatR;

namespace DnSocial.Api.Controllers.V1
{    
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseRoute)]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPosts());
            var mapped = _mapper.Map<List<PostResponse>>(result.Payload);
            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(mapped);
        }

        [HttpGet]
        [Route(ApiRoutes.Posts.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById(string id)
        {
            var postId = Guid.Parse(id);
            var query = new GetPostById() { PostId = postId};
            var result = await _mediator.Send(query);
            var mapped = _mapper.Map<PostResponse>(result.Payload);

            return result.IsError ? HandleErrorResponse(result.Errors) : Ok(mapped);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreatePost([FromBody] PostCreate newPost)
        {
            var command = new CreatePost()
            {
                UserProfileId = Guid.Parse(newPost.UserProfileId),
                TextContent = newPost.TextContent
            };

            var result = await _mediator.Send(command);
            var mapped = _mapper.Map<PostResponse>(result.Payload);

            return result.IsError ? HandleErrorResponse(result.Errors) :
                CreatedAtAction(nameof(GetById), new {id = result.Payload.UserProfileId}, mapped);
        }

        [HttpPatch]
        [ValidateModel]
        [ValidateGuid("id")]
        [Route(ApiRoutes.Posts.IdRoute)]
        public async Task<IActionResult> UpdatePostText([FromBody] PostUpdate updatedPost, string id)
        {
            var command = new UpdatePostText()
            {
                NewText = updatedPost.Text,
                PostId = Guid.Parse(id)
            };

            var result = await _mediator.Send(command);

            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }

        [HttpDelete]
        [Route(ApiRoutes.Posts.IdRoute)]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var command = new DeletePost()
            {
                PostId = Guid.Parse(id)
            };

            var result = await _mediator.Send(command);
            return result.IsError ? HandleErrorResponse(result.Errors) : NoContent();
        }


    }
}
