using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._11
{

    public class Program
    {
        public static void Main(string[] args)
        {
            double LenghtWord=0; //Количество символов в строке
            double CountOfWord = 0; //Количество слов
            string str = "asda# asdzx asdw, ывуasz! lol/ owaыszzwwp."; //Перевести в массив букв, проверить на IsLetter, пройтись разделителем.
            string[] MassOfWords = str.Split(' '); //Сначала переводим строку в массив слов, используя сплит.
            foreach (string x in MassOfWords) //считаем количество слов
            {
                 CountOfWord++;
            }
            char[] Mass = str.ToCharArray(); //Перевели в массив символов
            for(int i = 0; i<Mass.Length;i++) //убираем все не символы
            {
                if(!char.IsLetter(Mass[i])) Mass[i] = ' '; //я выбрал именно вариант IsLetter. Было ещё несколько вариантов, к примеру, отсеивать только
                //разделители. Минус текущего варианта - обнуляются так же и цифры. К примеру, слово: "asd7asf" - будет выглядить: "asd asf"
            }
            foreach(char x in Mass) //вывод чисто для наглядности
            {
                Console.Write(x);
            }
            Console.WriteLine();
            for(int i = 0; i<Mass.Length;i++) // подсчитываем символы.
            {
                if(Mass[i]!= ' ') //Если не равно пробелу - ++
                    LenghtWord++;
            }
            Console.WriteLine("Количество символов в словах: {0} ",LenghtWord);
            Console.WriteLine("Количество слов в строке: {0} ", CountOfWord);
            double Result = LenghtWord / CountOfWord;
            Console.WriteLine("Средняя арифметическая длина слов (c округлением) в заданной строке: {0} ", Math.Round(Result,3));
            Console.ReadKey();
        }
        //public class ForMass
        //{
        //    public void PrintMass(char[] mass)
        //    {
        //        for(int i = 0; i<mass.Length;i++)
        //        {
        //            Console.Write("{0} ", mass[i]);
        //        }
        //    }
        //}
    }
}
