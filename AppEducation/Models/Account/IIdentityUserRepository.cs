using System.Collections.Generic;

namespace AppEducation.Models.Account {

    public interface IIdentityUserRepository {

        IEnumerable<IdentityUser> IdentityUsers { get; }

        IdentityUser GetUserByKey(long key);
        IdentityUser GetUserByUserName(string username);

        void AddIdentityUser(IdentityUser identityUser);
        bool Login(string username, string password);
        void ChangePassword(IdentityUser identityUser);

        void UpdateIdentityUser(IdentityUser identityUser);
        
        void UpdateAll(IdentityUser[] identityUsers);

        void Delete(IdentityUser identityUser);
    }
}