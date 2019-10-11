using Entities;
using Notes.BLL.Interfaces;
using Notes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLL
{
    public class UserLogic: IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public void DateOfImg()//метод для вывода инфы на персональной странице каждого арта (кто автор, лайки, и т.д.)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Art> GetAllArtsOfArtist(string artist)
        {
            return _userDao.GetAllArtsOfArtist (artist);
        }

        public IEnumerable<Art_4_Favorits> GetAllFavoritsOfArtist(string Name)
        {
            return _userDao.GetAllFavoritsOfArtist().Where(item => item.Artist_who_Favorit == Name);
        }

        void IUserLogic.CrewateNewAcc(User user)
        {
            _userDao.CrewateNewAcc(user);
            //string path = @"~/Pages/User/" + user.Name;
            //DirectoryInfo dirinfo = new DirectoryInfo(path);
            //if (!dirinfo.Exists)
            //{
            //    dirinfo.Create();
            //}
            //File.Copy(@"~/Pages/Default/Default_User/User.cshtml", @"~/Pages/User/" + user.Name + "/" + user.Name + ".cshtml");
        }

        public bool GetUserByName(string name, string pass)
        {
            pass = pass.GetHashCode().ToString();
            if (_userDao.GetUserByName(name, pass) == 1)
            {
                //_RoleNow = _userDao.GetUserByName(name, pass).Item2;
                return true;
            }
            else return false;
        }

        public string AddBallToArt(string username, int artID)
        {
            if (_userDao.AddBallToArt(_userDao.GetIDByName(username), artID))
            {
                return "Успешно";
            }
            else
            {
                return "Вы уже оценили этот арт";
            }
        }

        public IEnumerable<Art> LatestUpdate()
        {
            return _userDao.LatestUpdate();
        }

        public int LastIDofArt()
        {
            return _userDao.LastIDofArt();
        }

        public void UploadImg(string imageFullPath, string Art_name, string username, int ID)
        {
            _userDao.UploadImg(imageFullPath, Art_name, username, ID);
        }

        public Art GetArtById(int Art_ID)
        {
            return _userDao.GetArtById(Art_ID);
        }

        public IEnumerable<Art> Searcher(string Artist_name)
        {
            return _userDao.Searcher(Artist_name);
        }
    }
}
