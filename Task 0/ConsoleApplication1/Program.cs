using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try //поскольку программа маленькая, а сам я не знаю откуда может прилететь ошибка - обернул весь год в try/catch. В случае любоей ошибки будет хотя бы понятно в чём проблема.
            {
                int n; //переменная для всех трёх заданий.
                Console.WriteLine("Требуется ввод числа");
                string Enter = Console.ReadLine(); //считываем строку
                if (int.TryParse(Enter, out n)) //пытаемся перевести
                {
                  n = int.Parse(Enter); //Перевелось? Присваивавем
                }
                else
                {
                    /*Console.WriteLine("Валидация провалилась ლ(ಠ益ಠლ) ");*/
                    //подобные символы вызывают знаки вопроса в консоли. Думаю, проблема в кодировке. (UTF-8 и т.п.)
                    Console.WriteLine("Валидация провалилась!");
                    Console.ReadKey();
                    return; //Просто выход из проги т.к. не знаю как грамотно это сделать.
                }
                if (n <= 0) //проверка для первых двух заданий.
                {
                    Console.WriteLine("Число меньше или равно нулю!");
                    Console.ReadKey();
                    return;
                }
                                FoMeth obj = new FoMeth(n);
                obj.FirstMeth();
                Console.WriteLine();
                obj.SecondMeth();
                Console.WriteLine();
                obj.ThirdMeth();
            }
            catch (Exception e) //Обработка любого исключения.
            {
                Console.WriteLine("Всё пропало, босс! Всё пропалоо!");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
        }
        class FoMeth //прсто класс для методов. ООП там, все дела. Хотя валидации в самом классе нет.
        {
            int ostatok; //переменная для второго задания. Проверяет наличие остатка.
            int Num;
            public FoMeth(int n)
            {
                Num = n;
            }
            public void FirstMeth()
            {
                for (int i = 1; i < Num + 1; i++) //тело первого задания.
                {
                    if (i == Num)
                    {
                        Console.Write("{0}.", i); //Просто замена запятой на точки. Визуальное оформление.
                    }
                    else
                    {
                        Console.Write("{0}, ", i);
                    }
                }
                Console.WriteLine();
            }
            public void SecondMeth()
            {
                for (int i = 2; i < Num; i++) //тело второго задания.
                {
                    ostatok = Num % i;
                    if (ostatok != 0)
                    {
                        Console.WriteLine("Кстати, число {0} простое", Num);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Кстати, число {0} не простое", Num);
                        break;
                    }
                }
                if (Num == 1)         //костыль один.
                {
                    Console.WriteLine("Кстати, число {0} не простое", Num);
                }
                if (Num == 2)         //костыль два.
                {
                    Console.WriteLine("Кстати, число {0} простое", Num);
                }
            }
            public void ThirdMeth()
            {
                if (Num % 2 == 0)//тело третьего задания.
                {
                    Console.WriteLine("Число {0} не подходит для 3 задания ввиду своей чётности.", Num); //проверка условий задачи. Проверка на отрицательное значение было выше.
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("Вывожу на экран фигуру...");
                for (int i = 1; i < Num + 1; i++) //c массивом намного проще, нежели через for            Поправка №3. С continue проще через for
                {
                    Console.WriteLine();
                    for (int j = 1; j < Num + 1; j++)
                    {
                        if ((j == Num / 2 + 1) && (i == Num / 2 + 1))
                        {
                            Console.Write(" ");
                            continue;   /*как же это глупо выглядит... Говорим программе написать символ " " и закончить выполнение цикала. А потом сразу же продолжить. Всё ради того, что бы не было 
                             символа "*" на центральном месте. В противном случае строка либо просто не дописывается, либо символ " " влезает посреди ряда.*/
                            //break; //поправка №1. Код работает корректно даже без break. И я не понимаю почему.
                            /*Поправка №2. Кажется, понял. Вроде, мы говорил программе напечатать символ " ", а затем говорить не обращать внимание на печатание "*", который находиться вне этого If.
                            Т.е. просто переходим на следущую итерацию. (J++)*/
                        }
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Готово!");
                Console.ReadKey();
            }
        }
    }
}
