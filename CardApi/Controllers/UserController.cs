using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardApi.Model;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CardApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : APIBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.ListUsers();
        }
    }
}
