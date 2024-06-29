﻿using AutoMapper;
using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.Models;
using DnSocial.Application.UserProfiles.Queries;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DnSocial.Application.UserProfiles.QueryHandlers
{
    public class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, OperationResult<IEnumerable<UserProfile>>>
    {
        private readonly DataContext _ctx;
        public GetAllUserProfilesQueryHandler(DataContext ctx) 
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<IEnumerable<UserProfile>>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IEnumerable<UserProfile>>();
            result.Payload = await _ctx.UserProfiles.ToListAsync();
            return result;
        }
    }
}
