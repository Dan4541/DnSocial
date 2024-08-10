namespace DnSocial.Application.Posts.Commands
{
    public class UpdatePostText : IRequest<OperationResult<Post>>
    {
        public string NewText { get; set; }
        public Guid PostId { get; set; }
    }
}
