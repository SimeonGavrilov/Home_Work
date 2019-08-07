using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _5._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Прошу заранее простить мой русский в комментах/cw, но с английским я бы сам запутался.*/
            Console.WriteLine("При работе программы будет созданно две папки: основная рабочая папка, а так же папка, содержащая резервные копиии.");
            string WorkFolder="";
            string BackUpFolder = "";
            //string reg = @"/^[A-Za-z]{1}[:]{1}[\]{1}[a-zА-Я]{1}[a-zа-я]{2}[\а-я]{1}[а-я]{1,2}([\]{0,1})?( [а-я]{5})?([\]{0,1})?([a-z]{0,7})?([\]{0,1})?$/"; //- вылетает ArgumentException с причиной: "Не распознанно /a"
            while (string.IsNullOrEmpty(WorkFolder))
            {
                Console.WriteLine("Укажите рабочую папку.");
                WorkFolder = Console.ReadLine();
            }
            Console.WriteLine("Укажите резервную папку.");

            while (string.IsNullOrEmpty(BackUpFolder))
            {
                Console.WriteLine("Укажите резервную папку.");
                BackUpFolder = Console.ReadLine();
            }
            Restoration restor = new Restoration(WorkFolder, BackUpFolder);
            DoBackUp doback = new DoBackUp(WorkFolder, BackUpFolder);
            while (true)
            {
                Console.WriteLine("\t Режим логирования / режим отката  ? L/B");
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.L)
                {
                    Console.WriteLine();
                    Console.WriteLine("Включен режим логирования...");
                    doback.DoBack();
                    break;
                }

                if (keyInfo.Key == ConsoleKey.B)
                {
                    Console.WriteLine();
                    Console.WriteLine("Включен режим отката...");
                    restor.GimmeBack();
                    Console.ReadKey();
                    break;
                }
            }
        }
    }

    class Searcher//модуль отследования изменений в файле
    {
        FileSystemWatcher fsw;
        public Searcher(string path)
        {
            fsw = new FileSystemWatcher(path);
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);
        }
        public void Run()
        {
            fsw.EnableRaisingEvents = true;
        }
        void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine("Файл изменен!");
                fsw.EnableRaisingEvents = false; //отключаем слежение
            }


            finally
            {
                fsw.EnableRaisingEvents = true; //переподключаем слежение
            }
        }
    }
    public class DoBackUp
    {
        TimeSpan ts = new TimeSpan(0, 0, 30); //автосев каждые 30 секунд.
        static int count = 0;//счётчик backupов
        protected string _path;//откуда берём копию
        public string Path
        {
            get { return _path; }
            private set { }
        }
        protected string _backpath;//путь файлов, куда происходит логирование
        public string Backpath
        {
            get { return _backpath; }
            private set { }
        }

        public DoBackUp(string path, string backpath)
        {
            _path = path;
            _backpath = backpath;

        }

        public void DoBack()//метод каждые 30 секунд делает резервную копию
        {
            string backpath = Backpath + count;
            System.IO.Directory.CreateDirectory(backpath);
            string[] files = System.IO.Directory.GetFiles(Path); //получить в все файлы из этой директории
            try
            {
                foreach (var item in files)
                {
                    string fileName = System.IO.Path.GetFileName(item);//дай имя
                    string destFile = System.IO.Path.Combine(backpath, fileName);//пункт назнаения = путь до бэкапа + имя файла
                    System.IO.File.Copy(item, destFile, false); ;//копируем
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("В указанной папке, созданной для логов, уже присутствуют старые файлы логирования.");
                Console.WriteLine(e.Message);
            }
            count = count + 1;
            Thread.Sleep(ts);//спим
            DoBack();
        }
    }
    public class Restoration: DoBackUp
    {
        public Restoration(string path, string backup): base(path,backup)
        {

        }
        public void DeleteActual()//удаляет актуальную версию файлов
        {
            string[] directory = System.IO.Directory.GetFiles(Path);

            foreach (var file in directory)
            {
                File.Delete(file);
            }
        }

        public void GimmeBack()//возвращает нужную копию
        {
            string[] directory = System.IO.Directory.GetDirectories(Backpath);
            foreach (var item in directory)
            {
                Console.WriteLine("Резервная папка с порядковым номером №{0}, была создана: {1}", System.IO.Path.GetFileName(item), File.GetCreationTime(item));
            }
            string[] files = System.IO.Directory.GetDirectories(Backpath);
            DateTime BackTime;
            Console.WriteLine("Введите дату отката в формате (hh:mm:ss)");
            while (!DateTime.TryParse(Console.ReadLine(), out BackTime))
            {
                Console.WriteLine("Введите дату отката в формате (H:m:s)");
            }
            DeleteActual();
            foreach (var item in files)
            {
                FileInfo fi = new FileInfo(item);
                if (fi.CreationTime < BackTime)
                {
                    string str = System.IO.Path.GetFullPath(item);
                    ICopyBack(str);
                }
            }
            Console.WriteLine("Откат завершён.");
        }
        public void ICopyBack(string str)//само копирование
        {
            string[] files = System.IO.Directory.GetFiles(str);
            foreach (var item in files)
            {
                string fileName = System.IO.Path.GetFileName(item);
                string destFile = System.IO.Path.Combine(Path, fileName);
                System.IO.File.Copy(item, destFile, true); ;//копируем
            }
        }
    }
}
