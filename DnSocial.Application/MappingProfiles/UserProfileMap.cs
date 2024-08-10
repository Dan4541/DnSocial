namespace DnSocial.Application.MappingProfiles
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap() 
        {
            CreateMap<CreateUserCommand, BasicInfo>();
        }
    }
}
