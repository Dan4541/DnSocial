using AutoMapper;
using Dn.Domain.Aggregates.PostAggregate;
using DnSocial.Api.Contracts.Posts.Responses;

namespace DnSocial.Api.MappingProfiles
{
    public class PostMappings : Profile
    {
        public PostMappings() 
        {
            CreateMap<Post, PostResponse>();
            CreateMap<PostComment, PostCommentResponse>();
        }
    }
}
