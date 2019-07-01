using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._8
{
    class Program
    {
        static void Main(string[] args)
        {
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
            int[,,] mass3D =new int[n,n,n];
            Random r = new Random();
            for(int i = 0; i<n;i++)
            {
                for(int j =0; j<n;j++)
                {
                    for(int k = 0; k<n;k++)
                    {
                        mass3D[i, j, k] = r.Next(-10, 5); 
                    }
                }
            }
            int[,] mass2D = new int[n,n];
            for(int i = 0; i <n;i++)
            {
                for(int j = 0; j<n;j++)
                {
                    mass2D[i,j] = r.Next(-10,5);
                }
            }
            Mass obj = new Mass();
            Console.WriteLine("Вывод трёхмерного массива:");
            obj.PrintMass3D(mass3D, n);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сумма всех положительных элементов в 3D массиве равна {0}", obj.SumOfPositive(mass3D, n));
            Console.WriteLine("Сумма всех чётных элементов в 2D массиве равна {0}", obj.SumOfEven(mass2D, n));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Произвожу обнуление всех положительных элементов... в 3D массиве");
            obj.DoNull(mass3D, n);
            obj.PrintMass3D(mass3D, n);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Произвожу вывод двумерного массива:");
            obj.PrintMass2D(mass2D,n);
            Console.ReadKey();
        }
        class Mass
        {
            public void PrintMass3D(int[,,] arr, int n) // просто вывод массива
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine();
                        for (int k = 0; k < n; k++)
                        {
                            Console.Write("{0} ", arr[i,j,k]);
                        }
                    }
                }
            }
            public void PrintMass2D(int[,] arr, int n) // просто вывод массива
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < n; j++)
                    {
                            Console.Write("{0} ", arr[i, j]);
                    }
                }
            }
            public void DoNull(int[,,] arr, int n) //делаем нули из всех положительных значений
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if(arr[i,j,k] >= 0) arr[i,j,k] = 0;
                        }
                    }
                }
            }
            public int SumOfPositive(int[,,] arr, int n) //сумма положительных элементов массива
            {
                int summ = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (arr[i, j, k] > 0) summ += arr[i, j, k];
                        }
                    }
                }
                return summ;
            }
            public int SumOfEven(int[,] arr, int n) //сумма чётных элементов в массиве
            {
                int summ = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i + j) % 2 == 0) summ += arr[i, j];
                    }
                }
                return summ;
            }
        }
    }
}
