namespace DnSocial.Application.Enums
{
    public enum ErrorCode
    {
        NotFound = 404,
        ServerError = 500,

        //Validation errors range between 100 - 199
        ValidationError = 101,

        //Infrastructure errors range between 200 - 299
        IdentityUserAlreadyExists = 201,
        IdentityCreationFailed = 202,
        IdentityUserDoesNotExists = 203,
        IncorrectPassword = 204,
        UnknownError = 999

    }
}
