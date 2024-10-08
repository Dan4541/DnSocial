﻿namespace DnSocial.Application.Identity.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, OperationResult<string>>
    {
        private readonly DataContext _ctx;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public LoginCommandHandler(DataContext ctx, UserManager<IdentityUser> userManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _ctx = ctx;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<OperationResult<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<string>();

            try
            {
                var identityUser = await _userManager.FindByEmailAsync(request.Username);

                if (identityUser is null)
                {
                    result.IsError = true;
                    var error = new Error
                    {
                        Code = ErrorCode.IdentityUserDoesNotExists,
                        Message = $"Unable to find a user with the specified username"
                    };
                    result.Errors.Add(error);
                    return result;
                }

                var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.Password);

                if (!validPassword)
                {
                    result.IsError = true;
                    var error = new Error
                    {
                        Code = ErrorCode.IncorrectPassword,
                        Message = $"The provided password is incorrect"
                    };
                    result.Errors.Add(error);
                    return result;
                }

                var userProfile = await _ctx.UserProfiles
                    .FirstOrDefaultAsync(up => up.IdentityId == identityUser.Id);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
                        new Claim("IdentityId", identityUser.Id),
                        new Claim("UserProfileId", userProfile.UserProfileId.ToString())
                    }),

                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddHours(2),
                    Audience = _jwtSettings.Audiences[0],
                    Issuer = _jwtSettings.Issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                result.Payload = tokenHandler.WriteToken(token);
                return result;

            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{ex.Message}"
                };
                result.IsError = true;
                result.Errors.Add(error);
            }

            return result;

        }
    }
}
