using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        public static string[,] PrintIf(int size, string[,] array)//функция вывода готового массива
        {
            //двумерный массив для вывода
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
        public static string[,] FillArray(int size, string[,] array)//создане исходного массива для заполнения
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = "";// создание пустово массива
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            string x = Console.ReadLine();// ввод количества строк
            int ss = int.Parse(x);// конвертация string в integer
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
