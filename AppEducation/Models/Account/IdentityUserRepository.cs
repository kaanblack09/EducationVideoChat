using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppEducation.Models.Account {

    public class IdentityRepository : IIdentityUserRepository {
        private AppDbContext context;

        public IdentityRepository(AppDbContext ctx) => context = ctx;

        public IEnumerable<IdentityUser> IdentityUsers => context.IdentityUsers
            .Include(u => u.UserInformation).ToArray();

        public IdentityUser GetUserByKey(long key) => context.IdentityUsers
            .Include(u => u.UserInformation).First(u => u.Id == key);
        public IdentityUser GetUserByUserName(string username) => context.IdentityUsers
            .Include(u => u.UserInformation).First(u => u.UserName == username);
        public void AddIdentityUser( IdentityUser identityUser) {
            context.IdentityUsers.Add(identityUser);
            context.SaveChanges();
        }

         public void UpdateIdentityUser(IdentityUser identityUser) {
            IdentityUser IU = context.IdentityUsers.Find(identityUser.Id);
            IU.UserName = identityUser.UserName;
            IU.Password = identityUser.Password;
            IU.Birthday = identityUser.Birthday;
            IU.Email = identityUser.Email;
            IU.Job = identityUser.Job;
            context.SaveChanges();
        }
        public bool Login(string username , string password)
        {
            List<IdentityUser> users = context.IdentityUsers.ToList();
            foreach(IdentityUser u in users)
            {
                if(u.UserName == username)
                {
                    if(u.Password == password)
                    {
                        return true;
                    }
                    else
                    return false;
                }
            }
            return false;
        }
        public void ChangePassword(IdentityUser identityUser) {
            IdentityUser IU = context.IdentityUsers.Find(identityUser.Id);
            IU.Password = IU.Password;
            context.SaveChanges();
        }

        public void UpdateAll(IdentityUser[] identityUsers) {
            Dictionary<long, IdentityUser> data = IdentityUsers.ToDictionary(u => u.Id);
            IEnumerable<IdentityUser> baseline = 
                context.IdentityUsers.Where(u => data.Keys.Contains(u.Id));

            foreach(IdentityUser databaseUser in baseline) {
                IdentityUser requestProduct = data[databaseUser.Id];
                databaseUser.UserName = requestProduct.UserName;
                databaseUser.Password = requestProduct.Password;
            }
           context.SaveChanges();
        }

        public void Delete(IdentityUser identityUser) {
            context.IdentityUsers.Remove(identityUser);
            context.SaveChanges();
        }

    }
}