using DaghanDigital.Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DaghanDigital.WebAPI.Filters
{
    public class ValidateFilterAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
                foreach (var item in errors)
                {
                    context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400,errors));
                }
            }
        }
    }
}
