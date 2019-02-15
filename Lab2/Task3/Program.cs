using System;
using System.IO;

namespace Task3
{
    public class Program
    {
        static void Main()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Asus\Pictures"); // переменная типа каталога с информацией об этом пути
            file_tree(dirInfo, 0); // вызов функции file_tree

        }

        static void file_tree(DirectoryInfo dirInfo, int k)
        { 
            // k - количество родительских каталогов.

            var files = dirInfo.GetFiles(); // список файлов в данном каталоге
            Console.ForegroundColor = ConsoleColor.Yellow; // файлы отображаются в желтом цвете
            foreach (var i in files)
            {
                for (int j = 0; j < 4 * k; j++)
                    Console.Write(' '); // делает отступ при показе элементов внутри родительской директории
                Console.ReadKey();
                Console.WriteLine(i.Name); // вывод имени файла
                Console.ReadKey();

            }
            var subdirs = dirInfo.GetDirectories(); // переменная для показа подкаталогов в родительской директории
            foreach (var i in subdirs)
            {
                Console.ForegroundColor = ConsoleColor.White; // цвет подкаталога white
                for (int j = 0; j < 4 * k; j++)
                    Console.Write(" "); // так же выставление отступов 
                Console.ReadKey();
                Console.WriteLine(i.Name); // вывод имени файлов
                Console.ReadKey();
                file_tree(i, k + 1); // рекурсия для определение подкаталогов в этом подкаталоге
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
