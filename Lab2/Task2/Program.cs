using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\git\Lab2\Task2\input.txt");//taking the string from the file
            string[] nums = text.Split(" ");
            int[] ints = Array.ConvertAll(nums, int.Parse);//converting all string elements into integers and adding into the array
            int j;
            for (int i = 0; i < ints.Length; i++)
            {
                // see if num is evenly divisible 
                for (j = 2; j < ints[i]; j++)
                    if ((ints[i] % j == 0))
                    {
                        break;
                    }
                if (j == ints[i])
                {
                    //as prime number was found it is inserted into the output file using StreanWriter
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\git\Lab2\Task2\output.txt", true))
                    {
                        file.Write(nums[i] + " ");
                    }

                }


            }
        }
    }
}
