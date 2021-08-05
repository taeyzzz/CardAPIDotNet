using System;
using System.Collections.Generic;
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

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public List<User> ListUsers()
        {
            return _userRepo.ListUsers();
        }

        public User UpdateUserById(Guid guid, User user)
        {
            throw new NotImplementedException();
        }
    }
}
