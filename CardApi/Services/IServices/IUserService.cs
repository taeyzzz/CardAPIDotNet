using System;
using System.Collections.Generic;
using CardApi.Model;

namespace CardApi.Services.IServices
{
    public interface IUserService
    {
        List<User> ListUsers();
        User GetUserById(Guid guid);
        User UpdateUserById(Guid guid, User user);
        User CreateUser(User user);
        void DeleteUserById(Guid guid);
    }
}
