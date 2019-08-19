using Awards.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Entities
{
    public interface IUsersStorage
    {
        bool AddUser(User user);
        bool DeleteUser(int id);
        ICollection<User> GetAllUsers();
        void SaveOnHardWare_DAL();
        bool GetFromHardWare_DAL();

        ICollection<Award> GetAllAwards_DAL();
        bool AddAward_DAL(int IDA, int ID);
    }
}
