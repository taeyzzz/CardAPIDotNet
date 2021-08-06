using System;
using System.Collections.Generic;
using CardApi.DTOs.User;
using CardApi.Model;
using CardApi.Repositories.IRepositories;
using CardApi.Services.IServices;

namespace CardApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
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
                Password = user.Password
            };
            return _userRepo.CreateUser(userModel);
        }

        public void DeleteUserById(Guid guid)
        {
            _userRepo.DeleteUserById(guid);
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
