using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Common;
using Entities;

namespace WebPL
{
    public static class PL_Web_Logic
    {
        public static void Add_User(string name, DateTime birth)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            UsersLogic.Add(new Entities.User()
            {
                Name = name,
                DateOfBirth = birth
            });

        }

        public static IEnumerable<Entities.User> Show_Users()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.GetAll();
        }
        public static void Delet_User(int Delete)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            UsersLogic.DeleteByID(Delete);
        }
    } 
}