using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.UserProfiles.Queries
{
    public class GetAllUserProfiles : IRequest<OperationResult<IEnumerable<UserProfile>>>
    {

    }
}
