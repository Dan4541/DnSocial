using DnSocial.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;

namespace DnSocial.Api.Filters
{
    public class DnSocialExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var apiError = new ErrorResponse();
            apiError.StatusCode = 500;
            apiError.StatusPhrase = "Internal Server Error";
            apiError.Timestamp = DateTime.Now;
            apiError.Errors.Add(context.Exception.Message);

            context.Result = new JsonResult(apiError) { StatusCode = 500 };
        }
    }
}
