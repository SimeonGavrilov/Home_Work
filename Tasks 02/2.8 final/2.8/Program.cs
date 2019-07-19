using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8_A1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Player = new Player(5, 5, 20, 30, 15);
            Mage_Spells Wrath = new Mage_Spells("Wrath", 5, 20);
            Mage_Spells Healing_Touch = new Mage_Spells("Healing_Touch", 10, 20);
            Rage_Spells Frenzy = new Rage_Spells("Frenzy", 50,60);
            Player.Spell_Book.Add(Wrath);
            Player.Spell_Book.Add(Healing_Touch);
            Player.Spell_Book.Add(Frenzy);
            Artefacts art = new Artefacts(10,10,50,50,50,"Любимая курочка Лироя",1);
            Player.Invetory.Add(art);
            foreach (var item in Player.Invetory)
            {
                Console.WriteLine(item);
            }
            //Paws.Active_Time = 100;
            Console.ReadKey();
        }
    }
    public abstract class Map
    {
        protected abstract int _X { get; set; }
        protected abstract int _Y { get; set; }
        int[,] _Array;
        public Map(int X, int Y)
        {
            _Array = new int[X, Y];
            _X = X;
            _Y = Y;
        }
        public void Filling_Map()//метод заполнения массива
        {
            Random r = new Random();
            for (int i = 0; i < _X; i++)
            {
                for (int j = 0; j < _Y; j++)
                    _Array[i, j] = r.Next(0, 2);
            }
        }
        public void PrintMap()
        {
            for (int i = 0; i < _X; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _Y; j++)
                    Console.Write("{0} ", _Array[i, j]);
            }
        }
        public bool Art()//проверка на наличие арта
        {
            if (_Array[_X, _Y] == 2) //крайне условно, допустим, значение 2 = наличию в клете артефакта. В этом случае возвращается истинное значение. Эдакая проверка на поднятие предмета. 
            {
                _Array[_X, _Y] = 0; //клетка обнуляется в пустую, но возможную для прохода.
                return true;
            }
            else return false;
        }
    }

    interface IMovable //интерфейс для движимых объектов (игрок, НИПы)
    {
        void Move(int Move);
    }
    interface ILVLUpable //поднятие стат при поднятии бонуса.
    {
        void LVLUp();
    }

    public class Player : Map, IMovable, ILVLUpable
    {
        protected override int _X { get; set; } //координаты игрока по х и y
        protected override int _Y { get; set; }
        protected int _Stamina { get; set; } //выносливость
        public virtual int Stamina
        {
            get { return _Stamina; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Stamina = value;
            }
        }
        protected int _Intellect { get; set; } //инта
        public virtual int Intellect
        {
            get { return _Intellect; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Intellect = value;
            }
        }
        protected int _Spirit { get; set; }//дух
        public virtual int Spirit
        {
            get { return _Spirit; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Spirit = value;
            }
        }
        private double _HP//устанавливается в зависимости от других параметров
        {
            get { return _Stamina * 2 + _Spirit * 1.2; }
            private set { }
        }

        private double _MP//устанавливается аналогично HP
        {
            get { return _Intellect * 2 + _Spirit * 1.2; }
            private set { }
        }

        public Player(int X, int Y, int Stamina, int Intellect, int Spirit)
            : base(X, Y)
        {
            if (Stamina < 0) throw new IndexOutOfRangeException("Значение выносливости не может быть отрицательным!");
            else _Stamina = Stamina;

            if (Stamina < 0) throw new IndexOutOfRangeException("Значение интеллекта не может быть отрицательным!");
            else _Intellect = Intellect;

            if (Stamina < 0) throw new IndexOutOfRangeException("Значение духа не может быть отрицательным!");
            else _Spirit = Spirit;
        }
        public void Move(int Move)
        {
            switch (Move)
            {
                case 1:
                    //if(_Array[_X, _Y-1] != 1)
                    //{
                    //    _Array[_X,_Y] = 0;
                    //    _Array[_X, _Y-1] = 4;     Нужна проверка для движения. Т.е. если сверху непроходимая зона - движение отсутствует.
                    //}                             Аналогично для других кейсов, но я не буду там рассписывать для наглядности и простоты кода
                    //else
                    //{
                    //    break;
                    //}
                    Console.WriteLine("Двигаюсь вверх");
                    break;

                case 2:
                    Console.WriteLine("Двигаюсь вниз");
                    break;

                case 3:
                    Console.WriteLine("Двигаюсь налево");
                    break;

                case 4:
                    Console.WriteLine("Двигаюсь направо");
                    break;
            }
        }
        public void LVLUp()
        {
            if (base.Art() == true) //если игрок находиться на одном уровне с артефактом - поднятие арта и, соответственно, бонуса
            {
                //Invetory.Add(/*Артефакт в данном месте*/); не знаю как реализовать
                Intellect += 10; //некое поднятие уровня при поднятии бонуса.
                Stamina += 10;
            }
        }
        public List<Spells> Spell_Book = new List<Spells>();//тут все заклинания
        public List<Artefacts> Invetory = new List<Artefacts>();//инвентарь
    }
    public class Artefacts : Player
    {
        protected override int _X { get; set; }
        protected override int _Y { get; set; }
        protected int _Stamina
        {
            get { return base._Stamina += _Stamina; }
            private set { }
        }
        protected int _Intellect
        {
            get { return base._Intellect += _Intellect; }
            private set { }
        }
        protected int _Spirit
        {
            get { return base._Spirit += _Spirit; }
            private set { }
        }
        protected string _Name { get; set; }
        public string Name
        {
            get { return _Name; }
            private set { }
        }
        private int _ID { get; set; }
        public Artefacts(int X, int Y, int Stamina, int Intellect, int Spirit, string Name, int ID)
            : base(X, Y, Stamina, Intellect, Spirit)
        {
            _Name = Name;
            _ID = ID;
        }
        public override string ToString()//метод перевода свойств класса artefacts в листе Invetory в строку. Крч, на выходе получаем что и сколько стоит.
        {
            return "X: " + _X + "   Y: " + _Y + " Stamina: " + Stamina + " Intellect: " + Intellect + " Spirit " + Spirit + " Name: " + Name + " ID: " + _ID;
        }
        
    }
    public class NPC : Player, IMovable
    {
        protected override int _X { get; set; }
        protected override int _Y { get; set; }
        private int _Stamina { get; set; }
        private int _Intellect { get; set; }
        private int _Spirit { get; set; }
        private double _HP { get; set; }
        private double _MP { get; set; }

        public NPC(int X, int Y, int Stamina, int Intellect, int Spirit)
            : base(X, Y, Stamina, Intellect, Spirit)
        {

        }

        public new void Move(int Move) //для удаления ворнинга я поставил new
        {
            Random R = new Random();
            Move = R.Next(1, 5);
            switch (Move)
            {
                case 1:
                    //if(_Array[_X, _Y-1] != 1)
                    //{
                    //    _Array[_X,_Y] = 0;
                    //    _Array[_X, _Y-1] = 4;     Нужна проверка для движения. Т.е. если сверху непроходимая зона - движение отсутствует.
                    //}                             Аналогично для других кейсов, но я не буду там рассписывать для наглядности и простоты кода
                    //else                          Движение для НИПов через рандом
                    //{
                    //    break;
                    //}
                    Console.WriteLine("Двигаюсь вверх");
                    break;

                case 2:
                    Console.WriteLine("Двигаюсь вниз");
                    break;

                case 3:
                    Console.WriteLine("Двигаюсь налево");
                    break;

                case 4:
                    Console.WriteLine("Двигаюсь направо");
                    break;
            }
        }
    }

    interface IRemovable //интерфейс чисто для рассеивания заклинаний т.к. далеко не каждое можно снять. Это я вам как рестор друид говорю.
    {
        void Remove();
    }

    public abstract class Spells //абстрактный класс заклинаний.
    {
        protected abstract string _Name { get; set; } //название спелла
        public virtual string Name
        {
            get { return _Name; }
            private set { }
        }
        protected abstract double _Cost { get; set; } //цена каста
        public virtual double Cost
        {
            get { return _Cost; }
            private set { }
        }
        protected abstract double _Active_Time { get; set; }//время, которое спелл будет висеть
        public virtual double Active_Time
        {
            get { return _Active_Time; }
            private set { }
        }
        public Spells(string Name, double Cost, double Active_Time)
        {
            _Name = Name;
            if (Cost >= 0 & Active_Time > 0)
            {
                _Cost = Cost;
                _Active_Time = Active_Time;
            }
            else throw new IndexOutOfRangeException("Значение не может быть меньше нуля!");
        }

        public override string ToString()//метод перевода свойств класса spells в массиве Spell_Book в строку. Крч, на выходе получаем что и сколько стоит.
        {
            return "Name: " + Name + "   Cost: " + Cost + " Active Time: " + Active_Time;
        }
    }
    public class Mage_Spells : Spells, IRemovable
    {
        protected override string _Name { get; set; }
        protected override double _Cost { get; set; }
        protected override double _Active_Time { get; set; }
        public Mage_Spells(string Name, double Cost, double Active_Time)
            : base(Name, Cost, Active_Time)
        {

        }
        public void Remove() //диспел (рассеивание заклинаний)
        {
            _Active_Time = 0;
        }
    }
    public class Rage_Spells : Spells //разница просто в возможности рассеивания. Стоило ради этого создавать класс или можно было обойтись аналогичным булевским полем?
    {
        protected override string _Name { get; set; }
        protected override double _Cost { get; set; }
        protected override double _Active_Time { get; set; }
        public Rage_Spells(string Name, double Cost, double Active_Time)
            : base(Name, Cost, Active_Time)
        {

        }
    }
}


