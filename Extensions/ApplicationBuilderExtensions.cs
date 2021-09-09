using AspNetCoreVueStarter.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

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
                        ProcessException(exceptionHandlerFeature.Error, context);

                    await context.Response.WriteAsync(string.Empty);
                });
            });
        }

        private static void ProcessException(Exception exception, HttpContext context)
        {
            switch (exception)
            {
                case NotFoundException _:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    throw exception;
            }
        }
    }
}
