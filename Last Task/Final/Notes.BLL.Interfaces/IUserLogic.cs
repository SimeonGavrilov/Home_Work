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
        IEnumerable<Art> GetAllArtsOfArtist(string Name);
        void CrewateNewAcc(User user);
        IEnumerable<Art_4_Favorits> GetAllFavoritsOfArtist(string Name);
        void DateOfImg();

        bool GetUserByName(string username, string pass);

        string AddBallToArt(string username, int artID);

        IEnumerable<Art> LatestUpdate();
        int LastIDofArt();

        void UploadImg(string imageFullPath, string Art_name, string username, int ID);
        Art GetArtById(int Art_ID);
        IEnumerable<Art> Searcher(string Artist_name);
    }
}
