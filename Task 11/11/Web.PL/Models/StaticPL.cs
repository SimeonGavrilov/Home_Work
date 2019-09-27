using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User.Common;
using System.IO;

namespace Web.PL.Models
{
    public class StaticPL
    {
        
        public static bool Add_User(string name, DateTime birth, string pass, string path)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            if (CheckRole() == 1)
            {
                path = Files(path);
                UsersLogic.Add(new Entities.User()
                {
                    Name = name,
                    DateOfBirth = birth,
                    pass = pass.GetHashCode().ToString(),
                    Image = path
                });
                return true;
            }
            else return false;
        }

        public static IEnumerable<Entities.User> Show_Users()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.GetAll();
        }
        public static bool Delet_User(int Delete)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            if (CheckRole() == 1)
            {
                UsersLogic.DeleteByID(Delete);
                return true;
            }
            else return false;
        }
        public static bool AddAward(int user_id, int award_id)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            if (CheckRole() == 1)
            {
                UsersLogic.AddAward(user_id, award_id);
                return true;
            }
            else return false;
        }

        public static int CheckRole()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.RoleNow;
        }
        public static string Files(string path)
        {
            if (!Directory.Exists(@"C:\Users\Fennec\source\repos\11\Web.PL\Pages\Files"))
            {
                Directory.CreateDirectory(@"C:\Users\Fennec\source\repos\11\Web.PL\Pages\Files");
            }
            string FileName = Path.GetFileName(path);
            if (!File.Exists(@"C:\Users\Fennec\source\repos\11\Web.PL\Pages\Files\" + FileName))
            {
                File.Copy(path, @"C:\Users\Fennec\source\repos\11\Web.PL\Pages\Files\" + FileName);
            }
            else
            {

            }
            return @"Files\" + FileName;
        }
    }
}