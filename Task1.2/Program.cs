using System;
using System.Collections.Generic;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateArray();

            Console.ReadKey();
        }

        static void CreateArray()
        {
            ArrayLength(out uint n);
            int[] array = new int[n];
            FillingArray(array);
            Print(array, Moda(array), Median(array));
        }

        static void ArrayLength(out uint n)
        {
            Console.WriteLine("Введите натуральное число для длины массива");
            while (!uint.TryParse(Console.ReadLine(), out n) || n == 0)
            {
                Console.WriteLine("Введите натуральное число для длины массива");
            }
        }

        static void FillingArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(101);
            }
        }

        static List<int> Moda(int[] array)
        {
            int[] sortedArray = new int[array.Length];
            Array.Copy(array, 0, sortedArray, 0, array.Length);
            Array.Sort(sortedArray);
            List<int> moda = new List<int>();
            int count = 1;
            int maxValue = 0;
            for (int i = 0; i < sortedArray.Length - 2; i++)
            {
                if (sortedArray[i] != sortedArray[i + 1])
                {
                    count = 1;
                    continue;
                }
                else
                {
                    count++;
                    if (sortedArray[i + 1] != sortedArray[i + 2] && maxValue <= count)
                    {
                        if (count > maxValue)
                        {
                            moda.Clear();
                        }
                        maxValue = count;
                        count = 1;
                        moda.Add(sortedArray[i]);
                    }
                }
            }
            return moda;
        }

        static int Median(int[] array)
        {
            int[] sortedArray = new int[array.Length];
            Array.Copy(array, 0, sortedArray, 0, array.Length);
            Array.Sort(sortedArray);
            int middle = sortedArray.Length / 2;
            if (sortedArray.Length % 2 == 1)
            {
                return sortedArray[middle + 1];
            }
            else
            {
                return (sortedArray[middle] + sortedArray[middle + 1]) / 2;
            }
        }

        static void Print(int[] array, List<int> moda, int median)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            if (moda.Count == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Мода равна " + moda[0]);
            }
            else
            {
                Console.WriteLine();
                Console.Write("Мода равна ");
                foreach (int elem in moda)
                {
                    Console.Write(elem + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Медиана равна " + median);
        }
    }
}
