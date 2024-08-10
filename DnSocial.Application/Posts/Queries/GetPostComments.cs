namespace DnSocial.Application.Posts.Queries
{
    public class GetPostComments : IRequest<OperationResult<List<PostComment>>>
    {
        public Guid PostId { get; set; }
    }
}
