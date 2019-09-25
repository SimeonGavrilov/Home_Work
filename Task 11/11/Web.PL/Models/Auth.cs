using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User.Common;

namespace Web.PL.Models
{
    public static class Auth
    {
        public static bool CanLogin(string login, string password)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            if (UsersLogic.GetUserByName(login, password))
            {
                return true;
            }
            else return false;
        }
    }
}