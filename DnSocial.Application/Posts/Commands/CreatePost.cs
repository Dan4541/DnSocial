﻿namespace DnSocial.Application.Posts.Commands
{
    public class CreatePost : IRequest<OperationResult<Post>>
    {
        public Guid UserProfileId { get; set; }
        public string TextContent { get; set; }
    }
}
