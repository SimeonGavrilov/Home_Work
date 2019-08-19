using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Users.Entities;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;
using Awards.Entities;

namespace Users.DAL
{
    public class MemoryStorage: IUsersStorage
    {
        DataContractJsonSerializer Json_Obj = new DataContractJsonSerializer(typeof(List<User>));
        private static int IDCount;
        private static List<Award> Awards { get; set; }
        private static List<User> Users { get; set; }

        static MemoryStorage()
        {
            Awards = new List<Award>();
            Awards.Add(new Award() { IDA = 0, NameA = "...Gone!", Description = "Make a 200ly+ neutron jump." }); 
            Awards.Add(new Award() { IDA = 1, NameA = "Home... Sweet Home", Description = "Visit Solar system." });
            Awards.Add(new Award() { IDA = 2, NameA = "AW-some!", Description = "Be first to discover an Ammonia world." });
            Awards.Add(new Award() { IDA = 3, NameA = "Benefector", Description = "Being an EDSM Benefecator" });
            Users = new List<User>();
        }

        public bool AddUser(User user)
        {
            user.ID = IDCount;
            Users.Add(user);
            IDCount++;
            return true;
        }
        public bool DeleteUser(int id)
        {
            if (Users.Any(n => n.ID == id))
            {
                Users.RemoveAll(n => n.ID == id);
                return true;
            }
            else
                return false;
        }
        public ICollection<User> GetAllUsers()
        {
            return Users;
        }
        public void SaveOnHardWare_DAL()
        {
            XmlWriter writer = new XmlTextWriter("Json.xml", null);
            Json_Obj.WriteObject(writer, Users);
            writer.Close();
        }
        public bool GetFromHardWare_DAL()
        {
            if (!File.Exists("Json.xml"))
            {
                return false;
            }
            var fi = new FileInfo("Json.xml");
            if (fi.Length == 0)
            {
                return false;
            }
            XmlReader reader = new XmlTextReader("Json.xml");
            List<User> ReturnListOfUser = (List<User>)Json_Obj.ReadObject(reader);
            reader.Close();
            Users = ReturnListOfUser;
            foreach (var item in ReturnListOfUser)
            {
                if (item.ID >= IDCount)
                {
                    IDCount = item.ID + 1;
                }
            }
            return true;
        }
        public bool AddAward_DAL(int IDA, int ID)
        {
            foreach (var item in Users)
            {
                if (ID==item.ID)
                {
                    //item.Alist = new List<Award> { Awards[ID] };
                    item.Alist.Add(Awards[IDA]);
                    return true;
                }
            }
            return false;
        }

        public ICollection<Award> GetAllAwards_DAL()
        {
            return Awards;
        }
    }
}
