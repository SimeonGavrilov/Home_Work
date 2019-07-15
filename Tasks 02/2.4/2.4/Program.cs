using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "таунт агро ненависть. понедельник, три всадника апокалипсиса, кеша";
            string str1 = "asd";
            char[] mass = { 'в', 'о', 'д', 'а' }; ;
            char[] mass1 = { 'г', 'е', 'р', 'а' };
            char[] EndMass;
            MyString obj = new MyString();
            EndMass = obj.Copy(mass, mass1);
            foreach (char x in EndMass)
            {
                Console.Write(x);
            }

        }
    }
    public class MyString
    {
        private string _str { get; set; }
        private char[] _mass { get; set; }

        public char[] ToMass(string str) //перевод в массив из строки
        {
            _mass = str.ToCharArray();
            return _mass;
        }
        public string ToString(char[] array) //перевод в строку из массива
        {
            StringBuilder sb = new StringBuilder();
            foreach (char x in array)
            {
                sb.Append(x);
            }
            _str = sb.ToString();
            return _str;
        }
        public void Search(char ch) //Поиск элементов в массиве.
        {
            Console.WriteLine("Искомый элемент находиться на позициях:");
            for (int i = 0; i < _mass.Length; i++)
            {
                if (_mass[i] == ch)
                {
                    Console.Write("{0} ", i + 1);
                }
            }
        }
        public bool IsEquial(int i, int j) //сравнение двух элементов массива
        {
            if (_mass[i] == _mass[j]) return true;
            else return false;
        }
        /// <summary>
        /// Сложение двух массивов.
        /// </summary>
        /// <param name="mass">Первый char массив</param>
        /// <param name="mass1">Второй char массив</param>
        /// <returns>Возвращает новый массив</returns>
        public char[] Copy(char[] mass, char[] mass1) //сложение двух массивов
        {
            char[] NewMass = new char[mass1.Length + mass.Length];
            mass1.CopyTo(NewMass, 0);
            mass.CopyTo(NewMass, mass1.Length);
            return NewMass;
        }

        /// <summary>
        /// Сложение двух массивов.
        /// </summary>
        /// <param name="str">Строка</param>
        /// <param name="mass">char массив</param>
        /// <returns>Возвращает новый массив</returns>
        public char[] Copy(string str, char[] mass) //сложение двух массивов (перегрузка строка + массив) + в некоторой степени валидация
        {
            char[] StrMass = str.ToCharArray();
            char[] NewMass = new char[StrMass.Length + mass.Length];
            StrMass.CopyTo(NewMass, 0);
            mass.CopyTo(NewMass, StrMass.Length);
            return NewMass;
        }
        /// <summary>
        /// Сложение двух массивов. (Две строки переводятся в char[])
        /// </summary>
        /// <param name="str">Первая строка</param>
        /// <param name="str1">Вторая строка</param>
        /// <returns>Возвращает новый массив</returns>
        public char[] Copy(string str, string str1) //сложение двух массивов (перегрузка строка + строка) + в некоторой степени валидация
        {
            char[] StrMass = str.ToCharArray();
            char[] StrMass1 = str1.ToCharArray();
            char[] NewMass = new char[StrMass.Length + StrMass1.Length];
            StrMass.CopyTo(NewMass, 0);
            StrMass1.CopyTo(NewMass, StrMass.Length);
            return NewMass;
        }
    }
}
