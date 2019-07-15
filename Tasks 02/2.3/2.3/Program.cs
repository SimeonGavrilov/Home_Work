using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User obj = new User("Иван", "Ив1анов", "Иванович", DateTime.Parse("2007.11.1"));
            //Console.WriteLine(obj.GetDifferenceInYears(DateTime.Parse("2007.7.12"), DateTime.Now)); //напоминашка: формат год/число/месяц... наверное
            Console.ReadKey();
        }
    }
    public class User
    {
        private string _name;//Имя можно получить и изменить
        private string _secondName; //Фамилию так же можно изменить и получить
        private string _patronymic; // с отчеством сложнее, его нельзя менять, а где-то его даже нет //Возраст можно только получить, причём дата высчитывается от даты рождения.!!
        private DateTime _dateOfBirth; //дату рождения изменить нельзя
        private int years; //возраст
        public User(string Name, string SecondName, string Patronymic, DateTime DateOfBirth)
        {
            foreach (char x in Name)
            {
                if (char.IsDigit(x)) throw new ArgumentException("В имени не могут содержаться цифры!");
                else _name = Name;
            }
            foreach (char x in SecondName)
            {
                if (char.IsDigit(x)) throw new ArgumentException("В фамилии не могут содержаться цифры!");
                else _secondName = SecondName;
            }
            foreach (char x in Patronymic)
            {
                if (char.IsDigit(x)) throw new ArgumentException("В отчестве не могут содержаться цифры!");
                else _patronymic = Patronymic;
            }
            _dateOfBirth = DateOfBirth;


            years = DateTime.Now.Year - DateOfBirth.Year; //вычисление возраста

            if (DateOfBirth.Month == DateTime.Now.Month && DateTime.Now.Day < DateOfBirth.Day)
            {
                years--;
            }
            else
                if (DateTime.Now.Month < DateOfBirth.Month)
            {
                years--;
            }

        }
        public string Name //Реализация вывода/редактирования имени 
        {
            get { return _name; }
            set
            {
                foreach (char x in value)
                {
                    if (!char.IsDigit(x)) _name = value;
                    else throw new ArgumentException("В имени не могут содержаться цифры!");
                }
            }
        }
        public string SecondName //Реализация вывода/редактирования фамилии 
        {
            get { return _secondName; }
            set
            {
                foreach (char x in value)
                {
                    if (!char.IsDigit(x)) _secondName = value;
                    else throw new ArgumentException("В имени не могут содержаться цифры!");
                }
            }
        }
        public string Patronymic //Реализация вывода отчества 
        {
            get { return _patronymic; }
            private set { }
        }
        public DateTime DateOfBirth //Реализация вывода даты рождения 
        {
            get { return _dateOfBirth; }
            private set { }
        }
        public int Age //возраст
        {
            get { return years; }
            private set { }
        }
    }
}
