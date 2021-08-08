using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.DBContext;
using CardApi.Model;
using CardApi.Repositories.IRepositories;

namespace CardApi.Repositories
{
    public class UserRepository : IUserRepo
    {
        private AppDBContext _appDBContext;
        private List<User> _users;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
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
            var newUser = new User()
            {
                //Id = Guid.NewGuid(),
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password
            };
            _appDBContext.DBUser.Add(newUser);
            _appDBContext.SaveChanges();
            //var isDuplicatedUser = _users.Any(u => u.Email == newUser.Email);
            //if (isDuplicatedUser)
            //{
            //    throw new Exception("Duplicated Email");
            //}
            //_users.Add(newUser);
            return newUser;
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
            return _appDBContext.DBUser.ToList();
            return _users;
        }

        public User UpdateUserById(Guid guid, User user)
        {
            _users = _users.Select(u => u.Id == guid ? UpdateUser(u, user) : u).ToList();
            var updatedUser = _users.FirstOrDefault(u => u.Id == guid);
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
