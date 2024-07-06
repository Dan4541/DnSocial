using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.Posts.Queries
{
    public class GetAllPosts : IRequest<OperationResult<List<Post>>>
    {

    }
}
