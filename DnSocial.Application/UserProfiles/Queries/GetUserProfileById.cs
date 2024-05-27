using Dn.Domain.Aggregates.UserProfileAggregate;
using MediatR;

namespace DnSocial.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; }
    }
}
