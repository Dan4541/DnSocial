using Dn.Domain.Aggregates.PostAggregate;
using Dn.Domain.Exceptions;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using DnSocial.Application.Posts.Commands;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DnSocial.Application.Posts.CommandHandlers
{
    public class AddPostCommentHandler : IRequestHandler<AddPostComment, OperationResult<PostComment>>
    {
        private readonly DataContext _ctx;

        public AddPostCommentHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<PostComment>> Handle(AddPostComment request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<PostComment>();

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

                var comment = PostComment.CreatePostComment(request.PostId, request.CommentText, request.UserProfileId);
                
                post.AddPostComment(comment);
                _ctx.Posts.Update(post);
                await _ctx.SaveChangesAsync();

                result.Payload = comment;

            }
            catch (PostCommentNoValidException e)
            {
                result.IsError = true;
                e.ValidationErrors.ForEach(x => {

                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{e.Message}"
                    };
                    result.Errors.Add(error);
                });
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
