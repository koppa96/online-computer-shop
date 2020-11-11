using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineComputerShop.Dal.Exceptions;

namespace OnlineComputerShop.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Unhandled exception caught.");
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            switch (e)
            {
                case EntityNotFoundException _:
                    context.Response.StatusCode = 404;
                    await WriteJsonAsync(context.Response, new ProblemDetails
                    {
                        Status = 404,
                        Title = "Not Found",
                        Detail = e.Message
                    });
                    break;
                case ValidationException _:
                    context.Response.StatusCode = 400;
                    await WriteJsonAsync(context.Response, new ProblemDetails
                    {
                        Status = 400,
                        Title = "Bad Request",
                        Detail = e.Message
                    });
                    break;
                case UnauthorizedException _:
                    context.Response.StatusCode = 403;
                    await WriteJsonAsync(context.Response, new ProblemDetails
                    {
                        Status = 403,
                        Title = "Forbidden",
                        Detail = e.Message
                    });
                    break;
                default:
                    context.Response.StatusCode = 500;
                    await WriteJsonAsync(context.Response, new ProblemDetails
                    {
                        Status = 500,
                        Title = "Internal Server Error",
                        Detail = e.Message
                    });
                    break;
            }
        }

        private static Task WriteJsonAsync(HttpResponse response, object @object)
        {
            return response.WriteAsync(JsonSerializer.Serialize(@object));
        }
    }
}