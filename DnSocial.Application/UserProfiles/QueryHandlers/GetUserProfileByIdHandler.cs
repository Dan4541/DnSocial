namespace DnSocial.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();
            var profile = await _ctx.UserProfiles.FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);

            if (profile is null)
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

            result.Payload = profile;

            return result;
        }
    }
}
