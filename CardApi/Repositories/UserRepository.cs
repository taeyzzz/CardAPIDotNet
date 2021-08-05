using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.Model;
using CardApi.Repositories.IRepositories;

namespace CardApi.Repositories
{
    public class UserRepository : IUserRepo
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "User1",
                    Lastname = "Last1",
                    Email = "user1@gmail.com",
                    Password = "password1"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "User2",
                    Lastname = "Last2",
                    Email = "user2@gmail.com",
                    Password = "password2"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "User3",
                    Lastname = "Last3",
                    Email = "user3@gmail.com",
                    Password = "password3"
                }
            };
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(Guid guid)
        {
            _users = _users.Where(u => u.Id != guid).ToList();
        }

        public User GetUserById(Guid guid)
        {
            var targetUser = _users.FirstOrDefault(u => u.Id == guid);
            return targetUser;
        }

        public List<User> ListUsers()
        {
            return _users;
        }

        public User UpdateUserById(Guid guid, User user)
        {
            var updatedUser = _users
                .Select(u => u.Id == guid ? UpdateUser(u, user) : u)
                .FirstOrDefault(u => u.Id == guid);
            return updatedUser;
        }

        private static User UpdateUser(User oldData, User newData)
        {
            return new User
            {
                Id = oldData.Id,
                Firstname = newData.Firstname ?? oldData.Firstname,
                Lastname = newData.Lastname ?? oldData.Lastname,
                Email = oldData.Email,
                Password = oldData.Password
            };
        }
    }
}
