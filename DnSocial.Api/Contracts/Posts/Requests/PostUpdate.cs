﻿namespace DnSocial.Api.Contracts.Posts.Requests
{
    public class PostUpdate
    {
        [Required]
        public string Text { get; set; }
    }
}
