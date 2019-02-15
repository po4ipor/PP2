using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string rev;
            string text = System.IO.File.ReadAllText(@"C:\Users\Asus\Documents\pp2\Lab2\Task\file.txt");//taking the text from the file
            char[] ch = text.ToCharArray();//turning the text into an array of chars
            Array.Reverse(ch);//reversing that array
            rev = new string(ch);//turning the char into one string
            if (text.Equals(rev, comparisonType: StringComparison.OrdinalIgnoreCase))//checks if the text is equal with rev
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
