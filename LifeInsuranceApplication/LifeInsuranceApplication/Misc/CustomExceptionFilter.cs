using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Misc
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
            public override void OnException(ExceptionContext context)
            {
                context.Result = new BadRequestObjectResult(new ErrorResponseDTO
                {
                    ErrorMessage = context.Exception.Message,
                    ErrorNumber = 500
                });
            }
        
    }
}
