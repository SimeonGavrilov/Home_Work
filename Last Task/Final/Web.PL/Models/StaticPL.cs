using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User.Common;
using System.IO;
using Entities;

namespace Web.PL.Models
{
    public class StaticPL
    {

        public static IEnumerable<Art> GetAllArtsOfArtist(string Name)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.GetAllArtsOfArtist(Name);
        }
        public static void CreateNewAcc(string username, string pass)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            UsersLogic.CrewateNewAcc(new Entities.User()
            {
                Name = username,
                pass = pass.GetHashCode().ToString(),
            });
        }

        public static IEnumerable<Art_4_Favorits> GetAllFavoritsOfArtist(string Name)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.GetAllFavoritsOfArtist(Name);
        }

        public static bool password_comparison(string pass, string r_pass, string username)
        {
            if (pass == r_pass & pass!=null & r_pass != null & username != null)
            {
                return true;
            }
            else return false;
        }
        //public static Art art = new Art();

        public static string press_like(int userID, int artID)
        {
            userID = 1;
            artID = 1;
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.AddBallToArt(userID, artID);
        }

        public static IEnumerable<Art> LatestUpdate()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.LatestUpdate();
        }

        public static int LastIDofArt()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            return UsersLogic.LastIDofArt();
        }
        public static void UploadImg(string imageFullPath, string Art_name, string username, int ID)
        {
            var UsersLogic = DependencyResolver.UserLogic;
            UsersLogic.UploadImg(imageFullPath, Art_name, username, ID);
        }
    }
}