using DnSocial.Api.Contracts.Common;
using DnSocial.Application.Enums;
using DnSocial.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace DnSocial.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();

                apiError.StatusCode = 400;
                apiError.StatusPhrase = "Bad Request";
                apiError.Timestamp = DateTime.Now;
                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    foreach (var inner in error.Value.Errors)
                    {
                        apiError.Errors.Add(inner.ErrorMessage);
                    }
                    
                }

                context.Result = new BadRequestObjectResult(apiError);
                //TO DO: Make sure asp.net core doesn't override our action result body
            }
        }
    }
}
