using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.Posts.Commands
{
    public class AddPostComment : IRequest<OperationResult<PostComment>>
    {
        public Guid PostId { get; set; }
        public Guid UserProfileId { get; set; }
        public string CommentText { get; set; }
    }
}
