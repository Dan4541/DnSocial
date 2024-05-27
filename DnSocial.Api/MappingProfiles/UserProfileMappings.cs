using AutoMapper;
using Dn.Domain.Aggregates.UserProfileAggregate;
using DnSocial.Api.Contracts.UserProfile.Reponses;
using DnSocial.Api.Contracts.UserProfile.Requests;
using DnSocial.Application.UserProfiles.Commands;

namespace DnSocial.Api.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings() 
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInfo>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInformation>();
        }
    }
}
