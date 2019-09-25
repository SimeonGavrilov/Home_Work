using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BLL.Interfaces
{
    public interface IUserLogic
    {
        int RoleNow { get; }

        int Add(User user);
        void DeleteByID(int ID);
        IEnumerable<User> GetAll();
        User GetByID(int id);
        void AddAward(int user_id, int award_id);
        bool GetUserByName(string name, string pass);
        void SwitchRole(int ID, int Role);

        
    }
}
