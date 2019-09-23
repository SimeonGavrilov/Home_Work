using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPL
{
    public static class Check
    {
        public static bool CanLogin(string login, string password)
        {
            return login == "Admin" & password == "Admin";
        }
    }
}