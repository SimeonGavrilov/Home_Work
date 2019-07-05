using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    class Program
    {
        public static void Main(string[] args)
        {
            string OutStr = "Параметры строки: italic,";
            string DefStr = "Параметры строки: None";
           Console.WriteLine(OutStr);
           Console.WriteLine("1: bold");
           Console.WriteLine("2: underline");
           Console.WriteLine("3: italic");
           Console.WriteLine("0: Exit");
           int num = 0;
           bool Exit = false; //переменная для выхода из программы
           bool Bool4Validate = false;
           string UndStr=""; //подстрока, которая понадобиться для редактирования OutStr
           while (Exit != true) //пока пользователь не захочет выйти нажатием на "0" - программа будет повторяться.
           {
               while (Bool4Validate != true) //Валидация с повторным запросом, если введено ошибочное значение.
               {
                   string Enter = Console.ReadLine();
                   if (int.TryParse(Enter, out num)) 
                   {
                       if ((num > -1) & (num < 4)) //дополнительные условия, вытекающие из задачи
                       {
                           num = int.Parse(Enter);
                           Bool4Validate = true;
                       }
                       else
                       {
                           Console.WriteLine("Укажите числовое значение из диапазона, представленного в таблице!");
                           break;
                       }
                   }
                   else
                   {
                       Console.WriteLine("Валидация провалилась! Введите значение ещё раз.");
                   }
               }
               switch (num)
               {
                   case 1:
                       UndStr = " bold,";
                       if (!(OutStr.Contains(UndStr))) //реализация вкл/выкл. Если отсутствует искомая подстрока - вставляем её.
                       {
                           OutStr = OutStr.Insert(OutStr.Length, UndStr);
                           Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       else //если искомая подстрока уже присутствует - удаляем. Ну и так везде.
                       {
                           int n = OutStr.IndexOf(UndStr); //ищем порядковый номер первого элемента в искомой подстроке
                           OutStr = OutStr.Remove(n, UndStr.Length); //удаляем подстроку с n позиции на длину подстроки
                           if ((!OutStr.Contains(" bold,")) & (!OutStr.Contains(" underline,") & (!OutStr.Contains(" italic,")))) Console.WriteLine(DefStr); //Если не содержит ни одного из заданных значений - подставляем
                           //строку с None
                           else Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       Bool4Validate = false;
                       break;

                   case 2:
                       UndStr = " underline,";
                       if (!(OutStr.Contains(UndStr)))
                       {
                           OutStr = OutStr.Insert(OutStr.Length, UndStr);
                           Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       else
                       {
                           int n = OutStr.IndexOf(UndStr);
                           OutStr = OutStr.Remove(n, UndStr.Length);
                           if ((!OutStr.Contains("bold, ")) & (!OutStr.Contains(" underline,") & (!OutStr.Contains(" italic,")))) Console.WriteLine(DefStr);
                           else Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       Bool4Validate = false;
                       break;

                   case 3:
                       UndStr = " italic,";
                       if (!(OutStr.Contains(UndStr)))
                       {
                           OutStr = OutStr.Insert(OutStr.Length, UndStr);
                           Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       else
                       {
                           int n = OutStr.IndexOf(UndStr);
                           OutStr = OutStr.Remove(n, UndStr.Length);
                           if ((!OutStr.Contains("bold, ")) & (!OutStr.Contains(" underline,") & (!OutStr.Contains(" italic,")))) Console.WriteLine(DefStr);
                           else Console.WriteLine(OutStr);
                           Console.WriteLine("1: bold");
                           Console.WriteLine("2: underline");
                           Console.WriteLine("3: italic");
                           Console.WriteLine("0: Exit");
                       }
                       Bool4Validate = false;
                       break;

                   case 0: //выход на 0
                       Exit = true;
                       break;
               }
           }
        }
    }
}
