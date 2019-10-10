using BLL;
using DAL;
using Notes.BLL.Interfaces;
using Notes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Common
{
    public static class DependencyResolver
    {
        
        private static readonly IUserLogic _userLogic;
        private static readonly IUserDao _userDao;

        public static IUserLogic UserLogic => _userLogic;


        public static IUserDao UserDao => _userDao;

        static DependencyResolver()
        {
            _userDao = new UserDao();
            _userLogic = new UserLogic(_userDao);
        }
    }
}
