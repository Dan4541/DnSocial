using Dn.Domain.Aggregates.UserProfileAggregate;
using Dn.Domain.Exceptions;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using DnSocial.Application.UserProfiles.Commands;
using DnSocial.Dal;
using MediatR;

namespace DnSocial.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInfoHandler : IRequestHandler<UpdateUserProfileBasicInfo, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileBasicInfoHandler(DataContext ctx) 
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInfo request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
                var userProfile = _ctx.UserProfiles.FirstOrDefault(up => up.UserProfileId == request.UserProfileId);

                if (userProfile == null)
                {
                    result.IsError = true;
                    var error = new Error { Code = Enums.ErrorCode.NotFound, 
                        Message = $"No User Profile with ID {request.UserProfileId} found."};

                    result.Errors.Add(error);
                    return result;
                }


                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                    request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

                userProfile.UpdateBasicInfo(basicInfo);

                _ctx.UserProfiles.Update(userProfile);
                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;

                return result;
            }
            catch (UserProfileNotValidException ex)
            {
                result.IsError = true;
                ex.ValidationErrors.ForEach(x => {

                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{ex.Message}"
                    };
                    result.Errors.Add(error);
                });
                return result;
            }
            catch (Exception ex)
            {
                var error = new Error { Code = ErrorCode.ServerError, Message = ex.Message };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;
        }
    }
}
