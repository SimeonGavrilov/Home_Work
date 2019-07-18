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
            Player Player = new Player(5,5,20,30,15);
            Mage_Spells Wrath = new Mage_Spells("Wrath", 5, 20);
            Mage_Spells Healing_Touch = new Mage_Spells("Healing_Touch", 10,20 );
            Player.Spell_Book.Add(Wrath);
            Player.Spell_Book.Add(Healing_Touch);
            foreach (var item in Player.Spell_Book)
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
        protected override int _X { get; set; }
        protected override int _Y { get; set; }
        private int _Stamina { get; set; }
        public virtual int Stamina
        {
            get { return _Stamina; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Stamina = value;
            }
        }
        private int _Intellect { get; set; }
        public virtual int Intellect
        {
            get { return _Intellect; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Intellect = value;
            }
        }
        private int _Spirit { get; set; }
        public virtual int Spirit
        {
            get { return _Spirit; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Значение выносливости не может быть отрицательным!");
                else _Spirit = value;
            }
        }
        private double _HP { get; set; }

        private double _MP { get; set; }

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
            if (base.Art() == true)
            {
                Intellect += 10; //некое поднятие уровня при поднятии бонуса.
                Stamina += 10;
            }
        }
        public List<Spells> Spell_Book = new List<Spells>();
    }
    public class Artefacts: Player
    {

        public Artefacts(int X, int Y, int Stamina, int Intellect, int Spirit, string Name, int ID)
            : base(X, Y, Stamina,Intellect,Spirit)
        {

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

    public abstract class Spells
    {
        protected abstract string _Name { get; set; }
        public virtual string Name
        {
            get { return _Name; }
             set { }
        }
        protected abstract double _Cost { get; set; }
        public virtual double Cost
        {
            get { return _Cost; }
             set { }
        }
        protected abstract double _Active_Time { get; set; }
        public virtual double Active_Time
        {
            get { return _Active_Time; }
             set { }
        }
        public Spells(string Name, double Cost, double Active_Time )
        {
            _Name = Name;
            _Cost = Cost;
            _Active_Time = Active_Time;
        }

        public override string ToString()//метод перевода свойств класса spells в массиве Spell_Book в строку. Крч, на выходе получаем что и сколько стоит.
        {
            return "Name: " + Name + "   Cost: " + Cost + " Active Time: " + Active_Time;
        }
    }
    public class Mage_Spells: Spells, IRemovable
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
}


