namespace DnSocial.Application.Posts.Commands
{
    public class DeletePost : IRequest<OperationResult<Post>>
    {
        public Guid PostId { get; set; }
    }
}
