using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double A = 3;
            double B = 4;
            double C = 5;
            Triangle obj = new Triangle(A, B, C);
            double Perimeter = obj.perimeter;
            double Square = obj.square;
            Console.WriteLine("Значение периметра равно {0}", Perimeter);
            Console.WriteLine("Значение площади равно {0}", Square);
            Console.ReadKey();

        }
    }
    public class Triangle
    {
        private double _a, _b, _c;
        public Triangle(double a, double b, double c)
        {
            if ((a > 0 & b > 0 & c > 0)) //Нужно прокинуть проверку на существование треугольника.
            {
                _a = a;
                _b = b;
                _c = c;
            }
            else throw new ArgumentOutOfRangeException("Значения должны быть больше нуля!");
            if ((a + b > c) & (b + c > a) & (a + c > b))
            {

            }
            else throw new ArgumentException("Данный треугольник не имеет право на существование!"); // Не знаю какая ошибка должна быть
            //выкинута в этом случае. Выбрал то, что понравилось больше всего.
        }
        public double perimeter
        {
            get { return _a + _b + _c; }
            private set { }
        }
        private double half_of_perimeter
        {
            get { return perimeter * 0.5; }
        }
        public double square //По формуле Герона. Вопрос что лучше: ввести отденое поле для полупериметра или в свойстве площади
        //добавить умножение периметра на 0.5
        {
            get
            {
                return Math.Sqrt(half_of_perimeter * ((half_of_perimeter - _a) * (half_of_perimeter - _b) * (half_of_perimeter - _c)));
            }
            private set { }
        }
    }
}
