using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        public static string[,] PrintIf(int size, string[,] array)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();

            }
            return array;
        }
        public static string[,] FillArray(int size, string[,] array)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = "";
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            int ss = int.Parse(x);
            string[,] arr = new string[ss, ss];
            for (int i = 0; i < ss; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    arr[i, j] = "[*]";
                }
            }
            PrintIf(ss, arr);
        }


    }
}
