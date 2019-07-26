using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class DynamicArray<T> : IEnumerator<T>
        {

        /// <summary>
        /// IEnumerator (10)
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() //dont forget "using System.Collections;"
            {
                for (int i = 0; i <= count; i++)
                    yield return array[i];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            /// <summary>
            /// Amount of memory
            /// </summary>
            public int Capacity
            {
                get { return array.Length; }
            }

            T[] array;

            /// <summary>
            /// The actual number of items
            /// </summary>
            private int _count;

            /// <summary>
            /// The actual number of items
            /// </summary>
            public int count
            {
                get { return _count; }
                protected set
                {
                    _count = value;
                }
            }
            /// <summary>
            /// Parameterless constructor(1)
            /// </summary>
            public DynamicArray()
            {
                this.array = new T[8];
                _count = 0;
            }
            /// <summary>
            /// Constructor with 1 parameter(2)
            /// </summary>
            /// <param name="length">array length</param>
            public DynamicArray(int length)
            {
                array = new T[length];
                _count = 0;
            }
            /// <summary>
            /// Constructor with 1 IEnumarable parameter(3)
            /// </summary>
            /// <param name="list">collection whic realize IEnumerable</param>
            public DynamicArray(IEnumerable<T> list)
            {
                int _count = 0;
                array = new T[list.Count()];
                foreach (var item in list)
                {
                    array[_count] = item;
                    _count++;
                }
            }
           /// <summary>
           /// Add to end (4)
           /// </summary>
           /// <param name="item">value</param>
            public void Add(T item)
            {
                if (count == Capacity)
                {
                    T[] _array = new T[1 << ((int)Math.Log(count, 2) + 1)]; //ближайшая степень 2 большая Count

                    // копируем в него исходный массив
                    for (int i = 0; i < count; i++)
                    {
                        _array[i] = array[i];
                    }

                    array = _array;
                }

                array[_count] = item;
                _count++;
            }
            
            /// <summary>
            /// add EInumerable to end(5)
            /// </summary>
            /// <param name="list"></param>
            public void AddListInEnd(IEnumerable<T> list)
            {
                if (list.Count() > array.Length - _count)
                {
                    T[] tmp = new T[1 << ((int)Math.Log(count, 2) + 1) + ((int)Math.Log(list.Count(), 2)+1)]; //ближайшая степень, которая больше count + минимальное значение, необходимое для листа
                    for (int i = 0; i < count; i++)
                    {
                        tmp[i] = array[i];
                    }

                    array = tmp;
                }
                foreach (var item in list)
                {
                    array[_count] = item;
                    _count++;
                }
            }

            /// <summary>
            /// remove at index(6)
            /// </summary>
            /// <param name="index">index of deleted elevent</param>
            /// <returns>removal was successful or not</returns>
            public bool RemoveAt(int index)
            {
                if (index >= count)
                {
                    //throw new IndexOutOfRangeException("Выход за границу массива");
                    return false;
                }
                for (int i = index; i < count - 1; i++) //сдвиг всех элементов после index влево на 1 позицию 
                {
                    array[i] = array[i + 1];
                }  
                array[count - 1] = default(T);
                count--;
                return true;
            }
            /// <summary>
            /// Add in certain place(7)
            /// </summary>
            /// <param name="_count">index of array</param>
            /// <param name="item">what paste</param>
            /// <returns>Add was successful or not</returns>
            public bool Insert(int _count, T item)
            {
                if (_count > array.Length - 1)
                {
                    return false;
                    //throw new ArgumentOutOfRangeException("Попытка обращения к индексу за пределами массива.");
                }
                if (_count <= array.Length)
                {
                    T[] mas = new T[array.Length * 2];
                    for (int i = 0; i <= _count; i++)
                    {
                        mas[i] = array[i];
                    }
                    mas[_count - 1] = item;
                    mas[_count] = array[_count - 1];
                    count++;
                    for (int i = _count; i < array.Length; i++)
                    {
                        mas[i + 1] = array[i];
                    }
                    array = mas;
                    return true;
                }
                else
                {
                    //Console.WriteLine("Попытка обращения к индексу за пределами массива.");
                    return false;
                    //throw new ArgumentOutOfRangeException("Попытка обращения к индексу за пределами массива.");
                }
            }

            /// <summary>
            /// Indexer (11)
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public T this[int number]
            {
                get
                {
                    if (number >= count)
                        throw new IndexOutOfRangeException("Выход за границу массива");
                    return array[number];
                }
                set
                {
                    if (number >= count)
                        throw new IndexOutOfRangeException("Выход за границу массива");
                    array[number] = value;
                }
            }
    }
}
