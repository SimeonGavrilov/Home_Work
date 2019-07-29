using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mass = new int[] { 1, 2, 3, 4, 5, 6 };
            double[] mass1 = new double[] { 1.2, 1.3, 2.2 };
            HelpClass obj = new HelpClass();
            obj.SumMass(mass);
            obj.SumMass(mass1);
            Console.WriteLine(obj.Sum);
            Console.ReadKey();
        }
    }
    public class HelpClass
    {
        private decimal sum = 0;
        public decimal Sum
        {
            get { return sum; }
            protected set { }
        }
        //static public T[] Concat<T, U>(this T[] arrayFirst, U[] arraySecond)
        //{
        //    T[] ret = arrayFirst.ToArray();
        //    if (arraySecond == null)
        //        return ret;
        //    for (int i = 0; i < arrayFirst.Length; i++)
        //    {
        //        arrayFirst[i] = (double)arrayFirst[i];
        //    }
        //    Array.Resize(ref ret, arrayFirst.Length + arraySecond.Length);
        //    Array.Copy(ret, arrayFirst.Length, arraySecond, 0, arraySecond.Length);
        //    foreach (var item in ret)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    return ret;
        //}
        public void SumMass(int[] mass)
        {
            sum = sum + (decimal)mass.Sum();
        }
        public void SumMass(double[] mass)
        {
            {
                sum = sum + (decimal)mass.Sum();
            }
        }
        public void SumMass(decimal[] mass)
        {
            {
                sum = sum + mass.Sum();
            }
        }
    }
}