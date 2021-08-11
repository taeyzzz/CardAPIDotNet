using System;
using System.Collections.Generic;
using System.Linq;
using CardApi.DBContext;
using CardApi.Middlewares.Error.Exceptions;
using CardApi.Model;
using CardApi.Repositories.IRepositories;

namespace CardApi.Repositories
{
    public class UserRepository : IUserRepo
    {
        private AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public User CreateUser(User user)
        {
            var createdUser = _appDBContext.Users.Add(user);
            _appDBContext.SaveChanges();
            return createdUser.Entity;
        }

        public void DeleteUserById(Guid guid)
        {
            var targetUser = GetUserById(guid);
            _appDBContext.Users.Remove(targetUser);
            _appDBContext.SaveChanges();
        }

        public User GetUserById(Guid id)
        {
            var targetUser = _appDBContext.Users.Find(id);
            if (targetUser == null)
            {
                throw new NotFoundException($"id {id} not found");
            }
            return targetUser;
        }

        public List<User> ListUsers()
        {
            return _appDBContext.Users.ToList();
        }

        public User UpdateUserById(Guid guid, User user)
        {
            var targetUser = GetUserById(guid);

            targetUser.Firstname = user.Firstname ?? targetUser.Firstname;
            targetUser.Lastname = user.Lastname ?? targetUser.Lastname;

            var updateUser = _appDBContext.Users.Update(targetUser);
            _appDBContext.SaveChanges();
            return updateUser.Entity;
        }

        public User GetUserByEmail(string email)
        {
            var user = _appDBContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new NotFoundException($"email {email} not found");
            }

            return user;
        }
    }
}
