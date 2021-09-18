using System;
using System.Collections.Generic;
using Application.DTOs.User;
using Domain.Entities;

namespace Application.Services.Users
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
