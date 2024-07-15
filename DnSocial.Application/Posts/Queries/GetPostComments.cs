using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.Posts.Queries
{
    public class GetPostComments : IRequest<OperationResult<List<PostComment>>>
    {
        public Guid PostId { get; set; }
    }
}
