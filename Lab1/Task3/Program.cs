using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static int[] doubleArray(int size, int[] mArray) //function to  double the main array
        {
            int[] dArray = new int[size * 2 + 1]; //defining an array
            for (int i = 0; i < size; i++)
            {
                dArray[2 * i + 1] = mArray[i]; //inserting the elements of the main array into the second array
            }
            for (int i = 1; i <= size; i++)
            {
                dArray[2 * i] = dArray[2 * i - 1]; 
            }
            return dArray;
        }

        static void Main(string[] args)
        {
            string x = Console.ReadLine();
            int ss = int.Parse(x);
            int[] array = new int[ss];
            string str = Console.ReadLine();
            array = str.Split(' ').Select(int.Parse).ToArray();// splitting the string and putting into array

            int[] doubled = doubleArray(ss, array);
            for (int i = 1; i <= ss * 2; i++) 
            {
                Console.Write(doubled[i] + " ");//showing the resultant array
            }
        }
    }
}
