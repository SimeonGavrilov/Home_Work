using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Notes.DAL.Interfaces
{
    public interface IUserDao
    {
        int Add(User user);
        void DeleteByID(int ID);
        IEnumerable<User> GetAll();
        void AddAward(int user_id, int award_id);
        //string GetHashPass();
    }
}
