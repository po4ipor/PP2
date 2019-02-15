using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
       public static bool primeN(int x)// boolean fuction to show if the number is prime or not
        {
            if (x <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) // if the mod to i is equal to 0 then returns false
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            int cnt = 0;//counter
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];//definig an array
            string s = Console.ReadLine();
            arr = s.Split(' ').Select(int.Parse).ToArray();//splitting the string and putting the numbers into array
            for (int i = 0; i < arr.Length; i++)
            {
                if (primeN(arr[i]) == true)//calling a function
                {
                    cnt++;
                }

            }
            Console.WriteLine(cnt);
            for (int i = 0; i < arr.Length; i++)
            {
                if (primeN(arr[i]) == true)
                {
                    Console.Write(arr[i] + " ");//output the prime numbers
                }
            }

        }
    }
}
