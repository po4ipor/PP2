using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "data.txt";
            string Path = @"C:\git\Lab2\Task4\path";
            string Path1 = @"C:\git\Lab2\Task4\path1";
            string sourceFile = System.IO.Path.Combine(Path, fileName);
            string destFile = System.IO.Path.Combine(Path1, fileName);
            if (!System.IO.Directory.Exists(Path1))//проверка существует ли директория path1
            {
                System.IO.Directory.CreateDirectory(Path1);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            if (System.IO.Directory.Exists(Path))
            {
                string[] files = System.IO.Directory.GetFiles(Path);


                foreach (string s in files)
                {
                    //итерация файлов и нахождение файла data.txt
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(Path1, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                //вывод если пути path не существует
                Console.WriteLine("Исходный путь не существует!");
            }

            if (System.IO.File.Exists(@"C:\git\Lab2\Task4\path\data.txt"))
            {

                try
                {
                    System.IO.File.Delete(@"C:\git\Lab2\Task4\path\data.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
