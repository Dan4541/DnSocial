namespace DnSocial.Api.MappingProfiles
{
    public class IdentityMappings : Profile
    {
        public IdentityMappings()
        {
            CreateMap<UserRegistration, RegisterIdentity>();
            CreateMap<Login, LoginCommand>();
        }
    }
}
