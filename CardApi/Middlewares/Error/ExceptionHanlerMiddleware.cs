using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using CardApi.Middlewares.Error.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CardApi.Middlewares
{
    public class ExceptionHanlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;
        public ExceptionHanlerMiddleware(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DbUpdateException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch (ForbiddenException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch (NotFoundException e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);
            if (exception is ResponseBaseException errorBase)
            {
                await context.Response.WriteAsJsonAsync(new { errorBase.Name, errorBase.Message });
            }
            else
            {
                await context.Response.WriteAsJsonAsync(new { exception.Message });
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, DbUpdateException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);
            await context.Response.WriteAsJsonAsync(new { exception.InnerException.Message});
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ForbiddenException => (int)HttpStatusCode.Forbidden,
                NotFoundException => (int)HttpStatusCode.NotFound,
                DbUpdateException => (int)HttpStatusCode.UnprocessableEntity,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
