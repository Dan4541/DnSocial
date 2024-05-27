using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.UserProfiles.Queries;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DnSocial.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _ctx;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
        }
    }
}
