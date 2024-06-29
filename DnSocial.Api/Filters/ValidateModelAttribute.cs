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
                    apiError.Errors.Add(error.Value.ToString());
                }

                context.Result = new JsonResult(apiError) { StatusCode = 400 };
                //TO DO: Make sure asp.net core doesn't override our action result body
            }
        }
    }
}
