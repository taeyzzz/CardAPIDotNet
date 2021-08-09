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
            var createdUser = _appDBContext.DBUser.Add(new User()
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password
            });
            _appDBContext.SaveChanges();
            return createdUser.Entity;
        }

        public void DeleteUserById(Guid guid)
        {
            var targetUser = GetUserById(guid);
            _appDBContext.DBUser.Remove(targetUser);
            _appDBContext.SaveChanges();
        }

        public User GetUserById(Guid id)
        {
            var targetUser = _appDBContext.DBUser.Find(id);
            if (targetUser == null)
            {
                throw new NotFoundException($"id {id} not found");
            }
            return targetUser;
        }

        public List<User> ListUsers()
        {
            return _appDBContext.DBUser.ToList();
        }

        public User UpdateUserById(Guid guid, User user)
        {
            var targetUser = GetUserById(guid);

            targetUser.Firstname = user.Firstname ?? targetUser.Firstname;
            targetUser.Lastname = user.Lastname ?? targetUser.Lastname;

            var updateUser = _appDBContext.DBUser.Update(targetUser);
            _appDBContext.SaveChanges();
            return updateUser.Entity;
        }
    }
}
