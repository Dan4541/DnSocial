using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.Models;
using DnSocial.Application.UserProfiles.Commands;
using DnSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnSocial.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserProfileHandler : IRequestHandler<DeleteUserProfile, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public DeleteUserProfileHandler(DataContext ctx) 
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(DeleteUserProfile request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
            _ctx.UserProfiles.Remove(userProfile);

            if (userProfile is null) 
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = Enums.ErrorCode.NotFound,
                    Message = $"No User Profile with ID {request.UserProfileId} found."
                };

                result.Errors.Add(error);
                return result;
            }

            await _ctx.SaveChangesAsync();
            result.Payload = userProfile;

            return result;
        }
    }
}
