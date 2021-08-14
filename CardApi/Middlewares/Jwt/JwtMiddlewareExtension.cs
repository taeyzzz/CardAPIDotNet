using Microsoft.AspNetCore.Builder;

namespace CardApi.Middlewares.Jwt
{
    public static class JwtMiddlewareExtension
    {
        public static void ConfigureJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
        }
    }
}