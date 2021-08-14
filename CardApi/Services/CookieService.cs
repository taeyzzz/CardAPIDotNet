using System;
using CardApi.Model;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace CardApi.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtService _jwtService;

        public CookieService(IHttpContextAccessor httpContextAccessor, IJwtService jwtService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtService = jwtService;
        }
        public void SetCookie(string name, string value)
        {
            var option = new CookieOptions()
            {
                Path = "/",
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(name, value, option);
        }
    }
}