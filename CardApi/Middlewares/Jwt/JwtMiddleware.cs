using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardApi.Services;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CardApi.Middlewares.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(
            RequestDelegate next, 
            IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtService jwtService)
        {
            var userToken = context.Request.Cookies["user-token"];
            if (userToken != null)
            {
                attachUserToContext(context, userService, jwtService, userToken);
            }

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, IJwtService jwtService, string token)
        {
            var jwtTokenData = jwtService.DecryptToken(token);
            var currentUser = userService.GetUserById(jwtTokenData.UserId);
            context.Items["CurrentUser"] = currentUser;
        }
    }
}