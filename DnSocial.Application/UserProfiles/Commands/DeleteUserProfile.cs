﻿using MediatR;

namespace DnSocial.Application.UserProfiles.Commands
{
    public class DeleteUserProfile : IRequest
    {
        public Guid UserProfileId { get; set; }
    }
}