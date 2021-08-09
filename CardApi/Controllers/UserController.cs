using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.DTOs.User;
using CardApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : APIBaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
    }
}
