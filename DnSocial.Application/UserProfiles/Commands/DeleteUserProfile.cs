using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.Models;
using MediatR;

namespace DnSocial.Application.UserProfiles.Commands
{
    public class DeleteUserProfile : IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
    }
}
