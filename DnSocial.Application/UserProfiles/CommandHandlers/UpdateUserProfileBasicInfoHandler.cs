using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Application.UserProfiles.Commands;
using DnSocial.Dal;
using MediatR;

namespace DnSocial.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInfoHandler : IRequestHandler<UpdateUserProfileBasicInfo>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileBasicInfoHandler(DataContext ctx) 
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(UpdateUserProfileBasicInfo request, CancellationToken cancellationToken)
        {
            var userProfile = _ctx.UserProfiles.FirstOrDefault(up => up.UserProfileId == request.UserProfileId);

            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

            userProfile.UpdateBasicInfo(basicInfo);

            _ctx.UserProfiles.Update(userProfile);
            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
