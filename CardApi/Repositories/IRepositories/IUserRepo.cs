using System;
using System.Collections.Generic;
using CardApi.DTOs.User;
using CardApi.Model;

namespace CardApi.Repositories.IRepositories
{
    public interface IUserRepo
    {
        List<User> ListUsers();
        User GetUserById(Guid guid);
        User UpdateUserById(Guid guid, User user);
        User CreateUser(User user);
        void DeleteUserById(Guid guid);
        User GetUserByEmail(string email);
    }
}
