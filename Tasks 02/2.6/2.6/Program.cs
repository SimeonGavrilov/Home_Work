using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //double Circumference;//Длина описанной окружности 
            //double Square;//Площадь окружности 
            //Round obj = new Round(5);
            //Square = obj.square;
            //Circumference = obj.circumference;
            //Console.WriteLine("Длина описанной окружности равна {0}", Circumference);
            //Console.WriteLine("Площадь окружности равна {0}", Square);
            Ring Ring = new Ring(10, 3, 4, 1, 2);
            Console.WriteLine(Ring.lenght_Of_Circles);
            Console.WriteLine(Ring.Square_Ring);
            Console.WriteLine(Ring.Square);
            Console.WriteLine(Ring.X);
            Console.ReadKey();
        }
    }
    public class Round
    {
        public Round(double Diameter)
        {
            if (Diameter > 0)
            {
                _diameter = Diameter;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
            }
        }
        private double _diameter;
        /// <summary>
        /// Диаметр
        /// </summary>
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
        /// <summary>
        /// Длина круга
        /// </summary>
        public double circumference
        {
            get
            {
                return Math.PI * _diameter;
            }
            private set { }
        }
        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Square
        {
            get
            {
                return Math.PI * (_diameter / 2) * (_diameter / 2);
            }
            private set { }
        }
    }
    class Ring : Round
    {
        private int _X;

        public int X
        {
            get { return _X; }
            set
            {
                if (value > 0)
                {
                    _X = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
                } 
            }
        }
        private int _Y;

        public int Y
        {
            get { return _Y; }
            set
            {
                if (value > 0)
                {
                    _Y = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Diameter">Диаметр</param>
        /// <param name="Inner_radius">Внутренний радиус</param>
        /// <param name="Outer_radius">Внешний радиус</param>
        /// <param name="X">Координата Х</param>
        /// <param name="Y">Координата Y</param>
        public Ring(double Diameter, double Inner_radius, double Outer_radius, int X, int Y)
            : base(Diameter)
        {
            if (Inner_radius < Diameter / 2 & Inner_radius < Outer_radius & Inner_radius < Diameter / 2 & Outer_radius > Inner_radius); //проверка на существование и корректность значений
            else
            {
                throw new ArgumentOutOfRangeException("Данное кольцо не имеет право на существование!");
            }

            if (Inner_radius > 0)
            {
                _inner_radius = Inner_radius;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
            }

            if (Outer_radius > 0)
            {
                _outer_radius = Outer_radius;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
            }
            _X = X; //как можно проверить эти два значения? Если бы ввод был с клавиатуры - Try.Parse. Тут не могу ничего придумать. Единственная защита - сам конструктор, который принимает конкретный тип
                    //значения.
            _Y = Y;

        }
        private double _inner_radius; //внутренний радиус
        private double _outer_radius; //внешний радиус

        /// <summary>
        /// Сумма длины окружностей кольца
        /// </summary>
        public double lenght_Of_Circles
        {
            get
            {
                return (2 * Math.PI * _inner_radius) + (2 * Math.PI * _outer_radius); //Да, я помню, что скобки не обязательны, но мне так спокойней
            }
            private set { }
        }
        /// <summary>
        /// Площадь кольца
        /// </summary>
        public double Square_Ring
        {
            get
            {
                return Math.PI * ((_outer_radius * _outer_radius) - (_inner_radius * _inner_radius)); //это площадь круга. И она совпадает с суммой длин окружностей кольца. Т.е. S = _inner_radius и _outer_radius
            }
            private set { }
        }
        /// <summary>www
        /// Свойство внешнего кольца
        /// </summary>
        public double Outer_radius
        {
            get { return _outer_radius; }
            set
            {
                if (value > 0)
                {
                    _inner_radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
                }
            }
        }

        /// <summary>
        /// Свойство внутреннего кольца
        /// </summary>
        public double Inner_radius 
        {
            get { return _outer_radius; }
            set 
            {
                if (value > 0)
                {
                    _outer_radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля!");
                }
            }
        }
        

    }
}
