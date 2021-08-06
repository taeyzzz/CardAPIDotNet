using System;
using Microsoft.AspNetCore.Builder;

namespace CardApi.Middlewares.Error
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHanlerMiddleware>();
        }
    }
}
