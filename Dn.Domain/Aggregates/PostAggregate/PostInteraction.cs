﻿namespace Dn.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction() { }
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }

        public static PostInteraction CreateInteraction(Guid postId, InteractionType type)
        {
            return new PostInteraction()
            {
                PostId = postId,
                InteractionType = type,
            };
        }

    }
}
