using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    class Program
    {
        public static void Main(string[] args)//напоминалка - добавь "using System.Collections;"
        {
            string str = "value1 value1 value2.value3 value3 arg.arg arg.arg.arg value1.value2 value1 value3";
            DoExc obj = new DoExc(str);
            obj.DoDictionary();
            obj.print();
            Console.ReadKey();
        }
        public class DoExc
        {
            Dictionary<string, int> dic = new Dictionary<string, int>(); //Do dictionare where key = word, value = how many times does it occur
            private int count = 0; //count of word
            string[] mass;
            public DoExc(string str)
            {
                mass = str.Split(new char[] { ' ', '.' });
            }
            public void DoDictionary()
            {
                for (int i = 0; i < mass.Length; i++)
                {
                    for (int j = 0; j < mass.Length; j++)
                    {
                        if (mass[i] == mass[j]) count++;
                    }
                    if (!dic.ContainsKey(mass[i]))//if key not meeting before
                    {
                        dic.Add(mass[i], count);//add
                        count = 0;//reset count of words
                    }
                    else//does not add for not cath exeption
                    {
                        count = 0;
                    }
                }
            }
            public void print()
            {
                foreach (KeyValuePair<string, int> keyvalue in dic)//вывод пары ключ-значение
                {
                    Console.WriteLine(keyvalue.Key + " - " + keyvalue.Value);
                }
                Console.ReadKey();
            }
        }
    }
}
