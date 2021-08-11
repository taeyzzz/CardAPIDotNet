using System;
using System.Collections.Generic;
using CardApi.DTOs.User;
using CardApi.Model;

namespace CardApi.Services.IServices
{
    public interface IUserService
    {
        List<User> ListUsers();
        User GetUserById(Guid guid);
        User UpdateUserById(Guid guid, UpdateUserDTO user);
        User CreateUser(CreateUserDTO user);
        void DeleteUserById(Guid guid);
        User Login(LoginRequestDTO loginRequestDto);
    }
}
