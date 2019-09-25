using Entities;
using Notes.BLL.Interfaces;
using Notes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserDao _userDao;

        private int _RoleNow;

        public int RoleNow
        {
            get { return _RoleNow; }
        }

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public int Add(User user)
        {
            return _userDao.Add(user);
        }

        public void AddAward(int user_id, int award_id)
        {
            _userDao.AddAward(user_id, award_id);
        }

        public void DeleteByID(int id)
        {
            _userDao.DeleteByID(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }
        public User GetByID(int id)
        {
            return _userDao.GetAll().FirstOrDefault(item => item.ID == id);
        }

        public bool GetUserByName(string name, string pass)
        {
            pass = pass.GetHashCode().ToString();
            if (_userDao.GetUserByName(name, pass) == 1)
            {
                //_RoleNow = _userDao.GetUserByName(name, pass).Item2;
                _RoleNow = _userDao.GetRoleByName(name, pass);
                return true;
            }
            else return false;
        }

        public void SwitchRole(int ID, int Role)
        {
            _userDao.SwitchRole(ID, Role);
        }

    }
}
