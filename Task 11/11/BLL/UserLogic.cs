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
    }
}
