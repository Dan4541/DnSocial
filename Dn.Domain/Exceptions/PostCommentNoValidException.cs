namespace Dn.Domain.Exceptions
{
    public class PostCommentNoValidException : NotValidException
    {
        internal PostCommentNoValidException(){}
        internal PostCommentNoValidException(string message) : base(message){ }
        internal PostCommentNoValidException(string message, Exception inner) : base(message, inner) { }
    }
}
