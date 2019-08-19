using Awards.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Common;
using Users.DAL;
using Users.Entities;

namespace Users.BLL
{
    public class UserManager
    {
        public static IUsersStorage MemoryStorage => Dependensies.UserStorage;
        public static void AddUser(User user)
        {
            MemoryStorage.AddUser(user);
        }
        public static void DeleteUser(int id)
        {
            MemoryStorage.DeleteUser(id);
        }
        public static ICollection<User> GetAllUsers()
        {
            return MemoryStorage.GetAllUsers();
        }
        public static void SaveOnHardWare_BLL()
        {
            MemoryStorage.SaveOnHardWare_DAL();
        }
        public static void GetFromHardWare_BLL()
        {
            MemoryStorage.GetFromHardWare_DAL();
        }
        public static void AddAward_BLL(int IDA, int ID)
        {
            MemoryStorage.AddAward_DAL(IDA,ID);
        }
        public static ICollection<Award> GetAllAwards_BLL()
        {
            return MemoryStorage.GetAllAwards_DAL();
        }
    }
}
