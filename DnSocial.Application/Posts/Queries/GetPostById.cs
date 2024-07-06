using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.Posts.Queries
{
    public class GetPostById : IRequest<OperationResult<Post>>
    {
        public Guid PostId { get; set; }
    }
}
