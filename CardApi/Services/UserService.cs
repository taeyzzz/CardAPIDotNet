using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using CardApi.DTOs.User;
using CardApi.Middlewares.Error.Exceptions;
using CardApi.Model;
using CardApi.Repositories.IRepositories;
using CardApi.Services.IServices;

namespace CardApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepo userRepo, IJwtService jwtService)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
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

                var token = _jwtService.GenerateToken(new JwtTokenData{ UserId = user.Id });
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
