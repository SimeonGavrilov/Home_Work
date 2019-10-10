using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Common;
using Entities;


namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            choise();
        }
        private static void choise()
        {
            var UsersLogic = DependencyResolver.UserLogic;
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Delete by ID");
            Console.WriteLine("3) Show all");
            Console.WriteLine("4) Show by ID");
            Console.WriteLine("5) Add award");
            Console.WriteLine("6)Switch Role of User");
            Console.WriteLine("7) Exit");
            var input = Console.ReadLine();
            uint num;
            if (uint.TryParse(input, out num)
                && num > 0
                && num < 7)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Add Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Add Date of birth");
                        DateTime birth;
                        while (!DateTime.TryParse(Console.ReadLine(), out birth))
                        {
                            Console.WriteLine("Ented date of birth in (yyyy-mm-dd) format");
                        }
                        Console.WriteLine("Add your password");
                        string pass = Console.ReadLine();
                        pass = pass.GetHashCode().ToString();
                        Console.WriteLine("Link on your image:");
                        string FilePath = Console.ReadLine();
                        //D:\yiff\else\QTSddYUxVRo.jpg
                        UsersLogic.Add(new Entities.User()
                        {
                            Name = name,
                            DateOfBirth = birth,
                            pass = pass,
                            Image = FilePath,
                            Role = 2
                        }) ;
                        choise();
                        break;
                    case 2:
                        Console.WriteLine("Enter ID of deleted user");
                        int Delete = int.Parse(Console.ReadLine());
                        UsersLogic.DeleteByID(Delete);
                        choise();
                        break;
                    case 3:
                        int pid = -1;
                        foreach (var item in UsersLogic.GetAll())
                        {
                            if (item.ID != pid)
                            {
                                pid = item.ID;
                                Console.WriteLine($"{item.ID} --- {item.Name} --- {item.age} --- {item.NameA} --- {item.DescriptionA}");
                            }
                            else
                            {
                                Console.WriteLine($"{item.NameA} --- {item.DescriptionA}");
                            }
                        }
                        choise();
                        break;
                    case 4:
                        Console.WriteLine("Enter ID of searching element");
                        int id = int.Parse(Console.ReadLine());
                        Entities.User UserById = UsersLogic.GetByID(id);
                        Console.WriteLine($"{UserById.ID} --- {UserById.Name} --- {UserById.DateOfBirth}");
                        choise();
                        break;
                    case 5:
                        Console.WriteLine("Whom give:");
                        int user_ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("What give:");
                        int award_ID = int.Parse(Console.ReadLine());
                        UsersLogic.AddAward(user_ID, award_ID);
                        choise();
                        break;
                    case 6:
                        Console.WriteLine("Whom swithc?");
                        int Sid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Whic role? (Admin - 1, User - 2)");
                        int Role = int.Parse(Console.ReadLine());
                        UsersLogic.SwitchRole(Sid, Role);
                        choise();
                        break;
                    case 7:
                        return;

                }
            }

        }
    }
}
