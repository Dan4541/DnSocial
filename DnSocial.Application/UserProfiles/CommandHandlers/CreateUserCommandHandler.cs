﻿using AutoMapper;
using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.UserProfiles.Commands;
using DnSocial.Dal;
using MediatR;

namespace DnSocial.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _ctx;

        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, 
                request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            _ctx.UserProfiles.Add(userProfile);
            await _ctx.SaveChangesAsync();

            return userProfile;
        }
    }
}
