using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Ring ring = new Ring(5,5,20,10,15);
            //Console.WriteLine(ring.Diametr);
            //ring.Inner_Ring = -1;
            //Console.WriteLine(ring.Inner_Ring);
            //Circle circ = new Circle(5,5,6);
            //Console.WriteLine(circ.Circumference);
            //Rec.Print();
            //Line.Print();
            //Circle.Print();
            Console.ReadKey();

        }
    }
    public abstract class Figure //абстрактная базовая фигура. Имеет только координаты Х и Y
    {
        protected abstract int _x { get; set; }
        protected abstract int _y { get; set; }
        protected Figure(int X, int Y)
        {
            _x = X;
            _y = Y;
        }
        public abstract void Print(); //Абстрактный метод вывода

    }
    public class Round : Figure //Реализация класса круга, унаследован от Фигуры
    {
        private double _Diametr { get; set; }
        public virtual double Diametr  //Из нового - диаметр круга и он виртуальный т.к. пригодится в классе Ring
        {
            get { return _Diametr; }
            set
            {
                if (Diametr > 0) _Diametr = Diametr;
                else throw new ArgumentOutOfRangeException("Число должно быть больше нуля!");
            }
        }
        protected override int _x { get; set; }
        protected override int _y { get; set; }
        public Round(int X, int Y, double Diametr)
            : base(X, Y)
        {
            if (Diametr > 0) _Diametr = Diametr;
            else throw new ArgumentOutOfRangeException("Число должно быть больше нуля!");

        }
        public override void Print()
        {
            Console.WriteLine("Вывод фигуры Круг с координатами {0}--{1} и диаметром {2}", _x, _y, _Diametr);
        }
    }
    public sealed class Ring : Round //Класс кольца унаследован от круга.
    {
        private double _Inner_Ring { get; set; } //Внутреннее кольцо
        public double Inner_Ring
        {
            get { return _Inner_Ring; }
            set
            {
                if ((value < 1) | (_Inner_Ring > _Outer_Ring)) throw new ArgumentOutOfRangeException("Внутреннее кольцо не может быть больше внешнего или быть больше диаметра!");
                else _Inner_Ring = value;
            }
        }
        private double _Outer_Ring { get; set; } //Внешнее кольцо (Внешнее кольцо должно быть равно диаметру?)
        public double Outer_Ring
        {
            get { return _Outer_Ring; }
            set
            {
                if ((value < 1) | (_Outer_Ring < _Inner_Ring)) throw new ArgumentOutOfRangeException("Внутреннее кольцо не может быть больше внешнего или быть больше диаметра!");
                else _Outer_Ring = value;
            }
        }
        private double _Diametr { get; set; }
        protected override int _x { get; set; }
        protected override int _y { get; set; }
        public Ring(int X, int Y, double Diametr, double Inner_Ring, double Outer_Ring)
            : base(X, Y, Diametr)
        {
            if (Inner_Ring > Diametr | Outer_Ring > Diametr | Inner_Ring > Outer_Ring) throw new ArgumentOutOfRangeException("Кольцо не имеет право на существование!");

            if (Inner_Ring > Outer_Ring | Inner_Ring > Diametr) throw new ArgumentOutOfRangeException("Внутреннее кольцо не может быть больше внешнего или быть больше диаметра!");
            else _Inner_Ring = Inner_Ring;

            if (Outer_Ring < Inner_Ring | Outer_Ring > Diametr) throw new ArgumentOutOfRangeException("Внешнее кольцо не может быть меньше внутреннего или больше диаметра");
            else _Outer_Ring = Outer_Ring;

        }
        public override void Print()
        {
            Console.WriteLine("Вывод кольца с координатами {0} {1}, диаметром {2}, внутренним кольцом, радиуса {3}, и внешним кольцом радиуса {4}.", _x, _y, _Diametr, _Inner_Ring, _Outer_Ring);
        }
    }

    public sealed class Circle : Figure //класс окружности, хотя я не знаю чем он отличается от круга
    {
        protected override int _x { get; set; }
        protected override int _y { get; set; }
        private double _Circumference { get; set; } //длина окружности
        public double Circumference
        {
            get { return _Circumference; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Длина окружности не может быть меньше единицы!");
                else _Circumference = value;
            }
        }
        public Circle(int X, int Y, double Circumference)
            : base(X, Y)
        {
            if (Circumference < 1) throw new ArgumentOutOfRangeException("Длина окружности не может быть меньше единицы!");
            else _Circumference = Circumference;
        }
        public override void Print()
        {
            Console.WriteLine("Вывод окружности с координатами {0} {1}, длиной окружности {2}", _x, _y, _Circumference);
        }
    }
    public sealed class Rectangle : Figure
    {
        protected override int _x { get; set; }
        protected override int _y { get; set; }
        private int _Width { get; set; }
        public int Width
        {
            get { return _Width; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Внутреннее кольцо не может быть больше внешнего или быть больше диаметра!");
                else _Width = value;
            }
        }
        private int _Height { get; set; }
        public int Height
        {
            get { return _Height; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Внутреннее кольцо не может быть больше внешнего или быть больше диаметра!");
                else _Height = value;
            }
        }
        public Rectangle(int X, int Y, int Width, int Height)
            : base(X, Y)
        {
            if (Width < 1) throw new ArgumentOutOfRangeException("Ширина не может быть отрицательной или равна нулю!");
            else _Width = Width;
            if (Height < 1) throw new ArgumentOutOfRangeException("Высота не может быть отрицательной или равна нулю!");
            else _Height = Height;

        }
        public override void Print()
        {
            Console.WriteLine("Вывод прямоугольника с координатами {0}--{1}, шириной {2} и высотой {3}", _x, _y, _Width, _Height);
        }
    }
    public sealed class Line : Figure
    {
        protected override int _x { get; set; }
        protected override int _y { get; set; }
        private int _End_x { get; set; }
        private int _End_y { get; set; }
        public Line(int X, int Y, int End_X, int End_Y)
            : base(X, Y)
        {
            _End_x = End_X;
            _End_y = End_Y;
        }
        public override void Print()
        {
            Console.WriteLine("Вывод линии, со стартом в {0}--{1} и концом в {2}--{3}", _x, _y, _End_x, _End_y);
        }
    }
}
