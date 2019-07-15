using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double Circumference;
            double Square;
            Round obj = new Round();
            obj.Diameter = 5;
            Square = obj.square;
            Circumference = obj.circumference;
            Console.WriteLine("Длина описанной окружности равна {0}", Circumference);
            Console.WriteLine("Площадь окружности равна {0}", Square);
            Console.ReadKey();
        }
    }
    public class Round
    {
        private double _diameter;
        public double Diameter
        {
            get { return _diameter; }
            set
            {
                if (value > 0)
                {
                    _diameter = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
                }
            }
        }
        public double circumference
        {
            get
            {
                return Math.PI * _diameter;
            }
            private set { }
        }
        public double square
        {
            get
            {
                return Math.PI * (_diameter / 2) * (_diameter / 2);
            }
            private set { }
        }
    }
}
