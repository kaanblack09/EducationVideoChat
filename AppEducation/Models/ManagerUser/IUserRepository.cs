using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEducation.Models.MangerUser
{
    public interface IUserRepository
    {
        User GetUser(long Id);
        IEnumerable<User> GetAllUser();
        User Add(User user);
        User Update(User userChange);
        User Delete(long Id);
    }
}
