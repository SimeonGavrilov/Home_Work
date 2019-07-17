using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8
{
public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
    interface IMovable //интерфейс для движимых объектов (игрок, НИПы)
    {
        void Move(int Move);
    }
    public class Map
    {
        protected int _X {get; set;}
        protected int _Y {get; set;}
        int[,] _Array;
        public Map(int X, int Y)
        {
            _Array = new int[X,Y];
            _X = X;
            _Y = Y;
        }
        public void Filling_Map()//метод заполнения массива
        {
            Random r = new Random();
            for (int i = 0; i<_X; i++)
            {
                for(int j = 0; j<_Y; j++)
                    _Array[i,j] = r.Next(0,2);
            }
        }
        public void PrintMap()
        {
            for (int i = 0; i<_X; i++)
            {
                Console.WriteLine();
                for(int j = 0; j<_Y; j++)
                    Console.Write("{0} ", _Array[i,j]);
            }
        }
    }
    public abstract class Pawn //НИПы + игрок
    {
        protected abstract int _X {get;set;}
        protected abstract int _Y {get;set;}
        public Pawn(int X, int Y)
        {
            _X=X; //Валидация граиц массива?
            _Y=Y;
        }
        private int _Stamina {get; set;} //выносливость
        public virtual int Stamina 
        {
            get {return _Stamina;}
            set
            {
                if(value < 0) throw new IndexOutOfRangeException("Значение выносливости не может быть отрицательным!");
                            else _Stamina = value;
            }
        }
        private int _Intellect {get; set;} //интеллект
        public virtual int Intellect
        {
            get {return _Stamina;}
            set
            {
                if(value < 0) throw new IndexOutOfRangeException("Значение интеллекта не может быть отрицательным!");
                            else _Intellect = value;
            }
        }
        private int _Spirit {get; set;} //дух (просто третий стат для себя и примера)
        public virtual int Spirit
        {
            get {return _Spirit;}
            set
            {
                if(value < 0) throw new IndexOutOfRangeException("Значение духа не может быть отрицательным!");
                            else _Spirit = value;
            }
        }
        private double _HP {get; set;}
        public virtual double HP
        {
            get {return (2 *_Stamina) + (0.5 * _Spirit);} //значение ХП не просто значение, а зависит от базовых стат.
        }
        private double _MP {get; set;}
        public virtual double MP
        {
            get {return (2 * _Intellect) + (0.5 * _Spirit);} // аналогично со значением Мана-пула
        }
    }
    public class Player: Pawn, IMovable
    {
        protected override int _X {get; set;}
        protected override int _Y {get; set;}
        protected int _Stamina {get; set;}
        protected int _Intellect {get; set;}
        protected int _Spirit {get; set;}
        protected int _HP {get; set;}
        protected int _MP {get; set;}
        
        public Player(int X, int Y, int Stamina, int Intellect, int Spirit): base(X,Y)
        {
             if(Stamina < 0) throw new IndexOutOfRangeException("Значение выносливости не может быть отрицательным!");
                 else _Stamina = Stamina;
            
             if(Stamina < 0) throw new IndexOutOfRangeException("Значение интеллекта не может быть отрицательным!");
                 else _Intellect = Intellect;
            
             if(Stamina < 0) throw new IndexOutOfRangeException("Значение духа не может быть отрицательным!");
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
    }
    public class NPC: Player, IMovable
    {
       protected int _X {get;set;}
       protected int _Y {get;set;}
       protected int _Stamina {get; set;}
       protected int _Intellect {get; set;}
       protected int _Spirit {get; set;}
       protected double _HP {get; set;}
       protected double _MP {get; set;}
        
        public NPC(int X, int Y, int Stamina, int Intellect, int Spirit): base(X,Y,Stamina, Intellect, Spirit)
        {
            
        }
        
        public void Move(int Move)
        {
            Random R = new Random();
            Move = R.Next(1,5);
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
    public abstract class Objects: Map
    {
        protected abstract int _X {get;set;}
        protected abstract int _Y {get;set;}
    }
    
    interface IRemovable
    {
        void Remove();
    }
    
    public abstract class Spells
    {
        protected double _Cost {get;set;} //цена спелла
        public virtual double Cost
        {
            get{return _Cost;}
            private set{}
        }
        
        protected double _Time_Of_Cust {get;set;} //время каста
        public virtual double Time_Of_Cust
        {
            get{return _Time_Of_Cust;}
            private set{}
        }
        
        protected double _Cooldown {get;set;} //откат
        public virtual double Cooldown
        {
            get{return _Cooldown;}
            private set{}
        }
        
        public virtual double Heal_Power
        {
            get{return (2 * _Intellect) + (1.3 * _Spirit);}
            private set{}
        }
        public virtual double Damage_Power
        {
            get { return (2 * _Intellect); }
            private set{}
        }
        public Spells(double Cost, double Time_Of_Cust, double Cooldown)
        {
            if(Cost < 0) throw new IndexOutOfRangeException("Значение стоимости заклинания не может быть меньше нуля!");
            else _Cost = Cost;
        }
    }
    public class Magic_Spells: Spells, IRemovable //Iremovable - можно рассеять. Класс обычных магических способностей
    {
        private double _Cost;
        private double _Time_Of_Cust;
        private double _Cooldown;
        private string _Shcool; //школа заклинания. Не знаю как в конструктор передать enum или List что-бы грамотно привязать тип
        public Magic_Spells(double Cost, double Time_Of_Cust, double Cooldown, string School): base(Cost, Time_Of_Cust, Cooldown)
        {
            _Shcool = School;
        }
        void Remove()
        {
            //Если на цель кастуется рассеивание - магические эффекты прекращают своё действие
        }
    }
    public class Rage_Spells: Spells //скиллы,которые работают не на магии, а на ярости (исступление и т.п.) рассеять невозможно
    {                                // но при этом имеют те же параметры, что и обычные спеллы.
        private double _Cost;
        private double _Time_Of_Cust;
        private double _Cooldown;
        public Rage_Spells(double Cost, double Time_Of_Cust, double Cooldown): base(Cost, Time_Of_Cust, Cooldown)
        {
            
        }
    }
}
