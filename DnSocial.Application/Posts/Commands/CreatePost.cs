using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.Posts.Commands
{
    public class CreatePost : IRequest<OperationResult<Post>>
    {
        public Guid UserProfileId { get; set; }
        public string TextContent { get; set; }
    }
}
