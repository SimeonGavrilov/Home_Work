using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mass
{
    class Program
    {
        static void Main(string[] args)
        {
            Mass obj = new Mass();
            int n;
            Console.WriteLine("Размерность массива");
            string N = Console.ReadLine();
            if (int.TryParse(N, out n)) n = int.Parse(N);
            else
            {
                Console.WriteLine("Валидация провалилась!");
                Console.ReadKey();
                return;
            }
            int[] mass = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++ )
            {
                mass[i] = r.Next(1,10);
            }
            obj.PrintMass(mass);
            Console.ReadKey();
            Console.WriteLine();
            obj.SortMass(mass, n);
            obj.PrintMass(mass);
            Console.WriteLine();
            Console.WriteLine("Максимальный элемент в массиве равен {0}. Минимальный элемент в массиве равен {1}", mass[0], mass[n-1]);
            Console.ReadKey();
        }
        class Mass
        {
            public void PrintMass(int[] arr)
            {
                foreach(int x in arr)
                {
                    Console.Write("{0}, ", x);
                }
            }
            public void SortMass(int[] arr, int n)
            {
                int value;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        if (arr[j + 1] > arr[j])
                        {
                            value = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = value;
                        }
                    }
                }
            }
            public void MaxAndMin(int[] arr, int n)
            {
            }
        }
    }
}
