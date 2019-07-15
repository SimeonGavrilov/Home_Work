using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            User Alex = new User("Alex", "Alex-евич","Николаевич", DateTime.Parse("1552.2.1"));
            Employee obj = new Employee("Иванов", "Иван", "Иванович", DateTime.Parse("1999.11.1"), DateTime.Parse("2007.11.1"), "Директор");//тут бы по хорошему формат даты проверить, но без маски не знаю как оптимально
            Console.WriteLine(Alex.SecondName);
            Console.WriteLine(Alex.Age);
            Console.WriteLine(obj.Age);
            Console.WriteLine(obj.work_experience);
            Console.WriteLine(obj.work_position);
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
    public class Employee : User
    {
        private int _work_experience;
        string _work_position;
        public Employee(string Name, string SecondName, string Patronymic, DateTime DateOfBirth, DateTime admission, string work_position) : base(Name, SecondName, Patronymic, DateOfBirth) //дата принятия на работу + должность
        {
            _work_position = work_position;

            _work_experience = DateTime.Now.Year - admission.Year; //вычисление стажа по тому же алгоритму, что и возраст. admission - дата принятия на работу

            if (admission.Month == DateTime.Now.Month && DateTime.Now.Day < admission.Day)
            {
                _work_experience--;
            }
            else
                if (DateTime.Now.Month < admission.Month)
                {
                    _work_experience--;
                }
        }
        public string work_position //вывод дожности
        {
            get { return _work_position; }
            private set { }
        }
        public int work_experience //вывод стажа
        {
            get { return _work_experience; }
            private set { }
        }
    }
}
