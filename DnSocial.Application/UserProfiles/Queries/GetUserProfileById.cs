using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
