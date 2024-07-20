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
