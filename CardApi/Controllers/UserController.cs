using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs.User;
using Application.Services.Users;
using CardApi.Model;
using CardApi.Services.Cookie;
using CardApi.Services.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : APIBaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly ICookieService _cookieService;

        public UserController(
            ILogger<UserController> logger, 
            IUserService userService, 
            IJwtService jwtService,
            ICookieService cookieService)
        {
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
            _cookieService = cookieService;
        }

        [HttpGet]
        public IEnumerable<UserDTO> HandleGetUsers()
        {
            _logger.LogInformation("Logging jaaaaaa");
            return _userService.ListUsers().Select(u => u.ToDTO());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserDTO> HandleGetUser([FromRoute] Guid id)
        {
            var user = _userService.GetUserById(id);
            return user.ToDTO();
        }

        [HttpPost]
        public ActionResult HandleCreateUser([FromBody] CreateUserDTO data)
        {
            var createdUser = _userService.CreateUser(data);
            return CreatedAtAction("HandleGetUser", new { id = createdUser.Id }, createdUser.ToDTO());
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<UserDTO> HandleUpdateuser([FromRoute] Guid id, [FromBody] UpdateUserDTO data)
        {
            var updatedUser = _userService.UpdateUserById(id, data);
            return updatedUser.ToDTO();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult HandleDeleteUser([FromRoute] Guid id)
        {
            _userService.DeleteUserById(id);
            return NoContent();
        }
        
        [HttpPost]
        [Route("login")]
        public ActionResult<UserDTO> HandleLogin([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = _userService.Login(loginRequestDto);
            var token = _jwtService.GenerateToken(new JwtTokenData {UserId = user.Id});
            _cookieService.SetCookie("user-token", token);
            return user.ToDTO();
        }
    }
}
