using System;
using System.Collections.Generic;
using Application.DTOs.User;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public User CreateUser(CreateUserDTO user)
        {
            var userModel = new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt())
            };
            return _userRepo.CreateUser(userModel);
        }

        public void DeleteUserById(Guid guid)
        {
            _userRepo.DeleteUserById(guid);
        }

        public User Login(LoginRequestDTO loginRequestDto)
        {
            try
            {
                var user = _userRepo.GetUserByEmail(loginRequestDto.Email);
                var authenticated = BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.Password);
                if (!authenticated)
                {
                    throw new UnauthorizedExecption();
                }
                return user;
            }
            catch (Exception e)
            {
                throw new UnauthorizedExecption();
            }
        }

        public User GetUserById(Guid guid)
        {
            return _userRepo.GetUserById(guid);
        }

        public List<User> ListUsers()
        {
            return _userRepo.ListUsers();
        }

        public User UpdateUserById(Guid guid, UpdateUserDTO user)
        {
            var userModel = new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
            return _userRepo.UpdateUserById(guid, userModel);
        }
    }
}
