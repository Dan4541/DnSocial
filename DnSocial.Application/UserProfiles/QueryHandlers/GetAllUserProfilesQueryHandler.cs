using AutoMapper;
using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.UserProfiles.Queries;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DnSocial.Application.UserProfiles.QueryHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _ctx;
        public GetAllUserProfilesQueryHandler(DataContext ctx) 
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.ToListAsync();
        }
    }
}
