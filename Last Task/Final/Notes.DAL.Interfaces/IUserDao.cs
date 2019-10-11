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
        IEnumerable<Art> GetAllArtsOfArtist(string artist);

        void CrewateNewAcc(User user);
        IEnumerable<Art_4_Favorits> GetAllFavoritsOfArtist();
        void DateOfImg();
        int GetUserByName(string username, string pass);

        bool AddBallToArt(int userID, int artID);
        IEnumerable<Art> LatestUpdate();

        int LastIDofArt();

        void UploadImg(string imageFullPath, string Art_name, string username, int ID);
        bool Check4Like(int Art_ID, int User_ID);
        int GetIDByName(string username);
        Art GetArtById(int Art_ID);

        IEnumerable<Art> Searcher(string Artist_name);
    }
}
