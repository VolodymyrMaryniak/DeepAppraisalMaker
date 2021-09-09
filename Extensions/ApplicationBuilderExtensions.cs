using AspNetCoreVueStarter.Exceptions;
using AspNetCoreVueStarter.Models.Errors;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCoreVueStarter.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseGlobalExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        await ProcessExceptionAsync(exceptionHandlerFeature.Error, context);
                    }
                });
            });
        }

        private static async Task ProcessExceptionAsync(Exception exception, HttpContext context)
        {
            switch (exception)
            {
                case NotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ValidationException validationException:
                    await ProcessValidationExceptionAsync(validationException, context);
                    break;
                default:
                    throw exception;
            }
        }

        private static async Task ProcessValidationExceptionAsync(ValidationException validationException, HttpContext context)
        {
            var error = new ErrorResponse
            {
                Error = new Error
                {
                    Message = validationException.Message,
                    Details = validationException.Errors?.Select(e => new ErrorDetails
                    {
                        Message = e.ErrorMessage,
                        Target = e.PropertyName
                    }).ToArray()
                }
            };

            var responseString = Newtonsoft.Json.JsonConvert.SerializeObject(error);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(responseString);
        }
    }
}
