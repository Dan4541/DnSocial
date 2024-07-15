using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using DnSocial.Application.Posts.Queries;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DnSocial.Application.Posts.QueryHandlers
{
    public class GetPostCommentsHandler : IRequestHandler<GetPostComments, OperationResult<List<PostComment>>>
    {
        private readonly DataContext _ctx;

        public GetPostCommentsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<List<PostComment>>> Handle(GetPostComments request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<PostComment>>();

            try
            {
                var post = await _ctx.Posts
                    .Include(p => p.Comments)
                    .FirstOrDefaultAsync(p => p.PostId == request.PostId);

                result.Payload = post.Comments.ToList();
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{ex.Message}"
                };
                result.IsError = true;
                result.Errors.Add(error);
            }


            return result;
        }
    }
}
