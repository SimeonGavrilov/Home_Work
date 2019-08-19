using System;
using Users.BLL;
using Users.Entities;
using System.Collections.Generic;
using Awards.Entities;
using System.Collections;

namespace _6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserManager.GetFromHardWare_BLL();
                choise();
            }
            finally
            {
                UserManager.SaveOnHardWare_BLL();
            }
            
            
        }
        private static void choise()
        {
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Delete");
            Console.WriteLine("3) Show");
            Console.WriteLine("4) Add award");
            Console.WriteLine("5) Exit");
            var input = Console.ReadLine();
            uint num;
            if (uint.TryParse(input, out num)
                && num > 0
                && num < 6)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Add name");
                        string name = Console.ReadLine();
                        while (!IsName(name))
                        {
                            Console.WriteLine("Incorrect name");
                            name = Console.ReadLine();
                        }
                        Console.WriteLine("Add date of birth");
                        DateTime birth;
                        while (!DateTime.TryParse(Console.ReadLine(), out birth))
                        {
                            Console.WriteLine("Ented date of birth in (yyyy-mm-dd) format");
                        }

                        if (birth > DateTime.Now)
                        {
                            Console.WriteLine("You cannot be born in the future!");
                            choise();
                            break;
                        }
                        var newUser = new User(name, birth);
                        UserManager.AddUser(newUser);
                        choise();
                        break;
                    case 2:
                        Console.WriteLine("Id of deleted user");
                        string str = Console.ReadLine();
                        int DelName;
                        bool IsDigit = int.TryParse(str, out DelName);
                        UserManager.DeleteUser(DelName);
                        choise();
                        break;
                    case 3:
                        IEnumerable<User> JustUsers = UserManager.GetAllUsers();
                        IEnumerable<Award> JustAwards = UserManager.GetAllAwards_BLL();
                        ShowAll(JustUsers, JustAwards);
                        choise();
                        break;
                    case 4:
                        IEnumerable<Award> AwardsForAdd = UserManager.GetAllAwards_BLL();
                        Console.WriteLine("Available rewards(): ");
                        ShowAwards(AwardsForAdd);
                        Console.WriteLine();
                        Console.WriteLine("Available for rewards: ");
                        IEnumerable<User> UsersForAddAwards = UserManager.GetAllUsers();
                        ShowUsers(UsersForAddAwards);
                        Console.WriteLine("Choose a reward ID and whom to reward.");
                        var InputIDA = Console.ReadLine();
                        int IDA;
                        var InputID = Console.ReadLine();
                        int ID;
                        if (int.TryParse(InputIDA, out IDA)
                            && IDA >=0
                            && IDA < 4
                            && int.TryParse(InputID, out ID)
                            && ID >= 0)
                        {
                            UserManager.AddAward_BLL(IDA, ID);
                        }
                        choise();
                        break;
                    case 5:
                        return;
                        
                }
            }

        }
        private static void ShowUsers(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine($"Name: {item._Name}, Date of Birth: {item._DateOfBirth.ToString("d")}, Ages: {item.age}, ID: {item.ID}");
            }
        }
        private static void ShowAll(IEnumerable<User> users, IEnumerable<Award> awards)
        {
            foreach (var item in users)
            {
                Console.Write($"Name: {item._Name}, Date of Birth: {item._DateOfBirth.ToString("d")}, Ages: {item.age}, ID: {item.ID}, Awards: ");
                Console.WriteLine();
                foreach(var item1 in item.Alist)
                {
                    Console.WriteLine($"{item1.NameA}/({item1.Description})");
                }
                Console.WriteLine();
            }
        }

        private static void ShowAwards(IEnumerable<Award> awards)
        {
            foreach (var item in awards)
            {
                Console.WriteLine($"ID: {item.IDA} --- {item.NameA}");
            }
                
        }
        private static bool IsName(string name)
        {
            foreach (char item in name)
            {
                if (char.IsDigit(item))
                {
                    return false;
                }
            }
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
    }
}
