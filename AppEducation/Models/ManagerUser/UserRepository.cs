using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEducation.Models.MangerUser
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(long Id)
        {
            User user = context.Users.Find(Id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUser()
        {
            return context.Users;
        }

        public User GetUser(long Id)
        {
            return context.Users.Find(Id);
        }

        public User Update(User userChange)
        {
            var userInformation = context.Users.Attach(userChange);
            userInformation.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChange;
        }
    }
}
