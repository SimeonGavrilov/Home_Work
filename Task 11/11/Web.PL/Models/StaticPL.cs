using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User.Common;

namespace Web.PL.Models
{
    public class StaticPL
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
        public static void AddAward(int user_id, int award_id)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            UsersLogic.AddAward(user_id, award_id);
        }
    }
}