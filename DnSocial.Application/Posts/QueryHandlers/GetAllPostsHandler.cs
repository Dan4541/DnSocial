namespace DnSocial.Application.Posts.QueryHandlers
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, OperationResult<List<Post>>>
    {
        private readonly DataContext _ctx;

        public GetAllPostsHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OperationResult<List<Post>>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<List<Post>>();

            try
            {
                var posts = await _ctx.Posts.ToListAsync();
                result.Payload = posts;
            }
            catch (Exception ex) 
            {
                var error = new Error { Code = ErrorCode.UnknownError, 
                    Message = $"{ ex.Message}" };
                result.IsError = true;
                result.Errors.Add(error);
            }
            return result;
        }
    }
}
