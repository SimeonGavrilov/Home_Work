using Awards.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Users.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID;

        [DataMember]
        public string _Name;

        [DataMember]
        public List<Award> Alist;


        [DataMember]
        public DateTime _DateOfBirth;

        [DataMember]
        public int age
        {
            get { return GetAge(_DateOfBirth); }
            private set { }
        }
        public User(string Name, DateTime DateOfBirth)
        {
            _Name = Name;
            _DateOfBirth = DateOfBirth;
            Alist = new List<Award>();
        }
        private static int GetAge(DateTime birth)
        {
            int ages;
            ages = DateTime.Now.Year - birth.Year; //вычисление возраста

            if (birth.Month == DateTime.Now.Month && DateTime.Now.Day < birth.Day)
            {
                ages--;
            }
            else
                if (DateTime.Now.Month < birth.Month)
            {
                ages--;
            }
            return ages;
        }
    }
}
