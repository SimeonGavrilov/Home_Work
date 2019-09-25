using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public enum Roles
        {
            Admin = 1,
            User = 2,
            Anon = 3
        }
        public int Role { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NameA { get; set; }
        public string DescriptionA { get; set; }

        public string Image;
        public string pass { get; set; }
        public int age
        {
            get { return GetAge(DateOfBirth); }
            set { }
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
