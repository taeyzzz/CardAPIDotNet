using System;
using Microsoft.AspNetCore.Http;

namespace CardApi.Services.Cookie
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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