namespace DnSocial.Api.Contracts.Posts.Requests
{
    public class PostCommentCreate
    {
        [Required]
        public string UserProfileId { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
