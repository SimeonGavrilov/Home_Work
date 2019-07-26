using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            bool delete = false; //bool value to remove every second
            while (list.Count != 1) //there must be only one
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (delete == true) list.RemoveAt(i--);
                    delete = !delete;
                }
                foreach (int x in list)
                {
                    Console.Write("{0} ", x);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
