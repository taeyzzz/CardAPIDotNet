using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardApi.Controllers
{
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        protected User GetContextUser()
        {
            return HttpContext.Items["CurrentUser"] as User;
        }
    }
}
