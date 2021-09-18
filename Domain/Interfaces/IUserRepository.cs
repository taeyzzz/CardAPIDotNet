using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        List<User> ListUsers();
        User GetUserById(Guid guid);
        User UpdateUserById(Guid guid, User user);
        User CreateUser(User user);
        void DeleteUserById(Guid guid);
        User GetUserByEmail(string email);
    }
}
