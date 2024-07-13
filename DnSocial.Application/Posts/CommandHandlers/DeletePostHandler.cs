using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using DnSocial.Application.Posts.Commands;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DnSocial.Application.Posts.CommandHandlers
{
    public class DeletePostHandler : IRequestHandler<DeletePost, OperationResult<Post>>
    {
        private readonly DataContext _ctx;

        public DeletePostHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<OperationResult<Post>> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();

            try
            {
                var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.PostId == request.PostId);

                if (post == null)
                {
                    result.IsError = true;
                    var error = new Error
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"No post found with the ID {request.PostId}"
                    };
                    result.Errors.Add(error);
                    return result;
                }

                _ctx.Posts.Remove(post);
                await _ctx.SaveChangesAsync();

                result.Payload = post;
            }
            catch (Exception ex)
            {
                var error = new Error { Code = ErrorCode.ServerError, Message = ex.Message };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}
