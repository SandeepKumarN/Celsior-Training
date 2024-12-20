﻿using EFCoreFirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreFirstAPI.Misc
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
