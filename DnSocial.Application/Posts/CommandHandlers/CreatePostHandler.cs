﻿using Dn.Domain.Aggregates.PostAggregate;
using Dn.Domain.Exceptions;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using DnSocial.Application.Posts.Commands;
using DnSocial.Dal;
using MediatR;

namespace DnSocial.Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, OperationResult<Post>>
    {
        private readonly DataContext _ctx;

        public CreatePostHandler(DataContext ctx) { _ctx = ctx; }

        public async Task<OperationResult<Post>> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Post>();
            try
            {
                var post = Post.CreatePost(request.UserProfileId, request.TextContent);
                _ctx.Posts.Add(post);
                await _ctx.SaveChangesAsync();

                result.Payload = post;
            }
            catch (NotValidException e)
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
            catch (Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;

        }
    }
}
